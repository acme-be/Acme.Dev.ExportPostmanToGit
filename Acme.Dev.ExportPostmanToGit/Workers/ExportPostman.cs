// <copyright file="ExportPostman.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Workers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text.Json;

    using Acme.Dev.ExportPostmanToGit.Application;
    using Acme.Dev.ExportPostmanToGit.Model;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Manage the export of postman to a local directory.
    /// </summary>
    public class ExportPostman
    {
        private const string BaseUrl = "https://api.getpostman.com";

        private readonly ILogger logger;
        private readonly PostmanConfiguration postmanConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportPostman" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="postmanConfiguration">The postman configuration.</param>
        public ExportPostman(ILogger<ExportPostman> logger, PostmanConfiguration postmanConfiguration)
        {
            this.logger = logger;
            this.postmanConfiguration = postmanConfiguration;
        }

        /// <summary>
        /// Run the exporter.
        /// </summary>
        public void Run()
        {
            this.logger.LogInformation("Starting the postman export");

            this.EnsureDestination();

            var workspaces = this.Get<PostmanWorkspaces>("/workspaces");
            this.SynchronizeWorkspaces(workspaces);

            foreach (var workspace in workspaces.Workspaces)
            {
                this.SynchronizeWorkspace(workspace);
            }
        }

        private void EnsureDestination()
        {
            Directory.CreateDirectory(this.postmanConfiguration.LocalDirectory);
        }

        private T Get<T>(string path)
        {
            var url = $"{BaseUrl}{path}";

            var request = WebRequest.CreateHttp(url);
            request.Headers.Add("X-Api-Key", this.postmanConfiguration.ApiKey);
            using var response = request.GetResponse();
            using var responseStream = response.GetResponseStream();
            using var streamReader = new StreamReader(responseStream ?? throw new InvalidOperationException("The response stream cannot be null"));
            var json = streamReader.ReadToEnd();

            return JsonSerializer.Deserialize<T>(json);
        }

        private string GetRaw(string path)
        {
            var url = $"{BaseUrl}{path}";

            var request = WebRequest.CreateHttp(url);
            request.Headers.Add("X-Api-Key", this.postmanConfiguration.ApiKey);
            using var response = request.GetResponse();
            using var responseStream = response.GetResponseStream();
            using var streamReader = new StreamReader(responseStream ?? throw new InvalidOperationException("The response stream cannot be null"));
            return streamReader.ReadToEnd();
        }

        private void SynchronizeWorkspace(PostmanWorkspaceInformation workspace)
        {
            var workspaceDetails = this.Get<PostmanWorkspace>("/workspaces/" + workspace.Id);

            var workspaceDirectory = Path.Combine(this.postmanConfiguration.LocalDirectory, workspace.Name);

            if (workspaceDetails.Workspace?.Collections != null)
            {
                foreach (var collection in workspaceDetails.Workspace.Collections)
                {
                    var collectionExport = this.GetRaw("/collections/" + collection.Uid);
                    var collectionPath = Path.Combine(workspaceDirectory, $"collection.{collection.Name}.json");
                    File.WriteAllText(collectionPath, collectionExport);
                    this.logger.LogInformation($"Collection {collection.Name} in workspace {workspace.Name} has been exported.");
                }
            }
            else
            {
                this.logger.LogDebug($"Skipped collections in workspace {workspace.Name}.");
            }

            if (workspaceDetails.Workspace?.Environments != null)
            {
                foreach (var environement in workspaceDetails.Workspace.Environments)
                {
                    var environementExport = this.GetRaw("/environments/" + environement.Uid);
                    var environmentPath = Path.Combine(workspaceDirectory, $"environment.{environement.Name}.json");
                    File.WriteAllText(environmentPath, environementExport);
                    this.logger.LogInformation($"Environement {environement.Name} in workspace {workspace.Name} has been exported.");
                }
            }
            else
            {
                this.logger.LogDebug($"Skipped environments in workspace {workspace.Name}.");
            }
        }

        private void SynchronizeWorkspaces(PostmanWorkspaces workspaces)
        {
            var directories = new DirectoryInfo(this.postmanConfiguration.LocalDirectory).GetDirectories();

            foreach (var workspace in workspaces.Workspaces)
            {
                if (directories.All(d => d.Name != workspace.Name))
                {
                    this.logger.LogInformation($"Create directory for workspace {workspace.Name}");
                    Directory.CreateDirectory(Path.Combine(this.postmanConfiguration.LocalDirectory, workspace.Name));
                }
            }

            foreach (var directory in directories)
            {
                if (workspaces.Workspaces.All(w => w.Name != directory.Name))
                {
                    this.logger.LogInformation($"Deleting directory for workspace {directory.Name}");
                    directory.Delete();
                }
            }
        }
    }
}