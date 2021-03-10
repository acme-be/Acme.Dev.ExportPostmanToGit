// <copyright file="PostmanWorkspace.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represent a workspace.
    /// </summary>
    public class PostmanWorkspace
    {
        /// <summary>
        /// Gets or sets the Workspace.
        /// </summary>
        /// <value>The Workspace.</value>
        [JsonPropertyName("workspace")]
        public PostmanWorkspaceDetails Workspace { get; set; }
    }
}