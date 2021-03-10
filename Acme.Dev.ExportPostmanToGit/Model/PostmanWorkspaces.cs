// <copyright file="PostmanWorkspaces.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Model
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represent a list of workspaces.
    /// </summary>
    public class PostmanWorkspaces
    {
        /// <summary>
        /// Gets or sets the Collections.
        /// </summary>
        /// <value>The Collections.</value>
        [JsonPropertyName("workspaces")]
        public List<PostmanWorkspaceInformation> Workspaces { get; set; }
    }
}