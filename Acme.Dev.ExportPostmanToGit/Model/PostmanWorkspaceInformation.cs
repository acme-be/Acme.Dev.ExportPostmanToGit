// <copyright file="PostmanWorkspaceInformation.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represent information about a workspace.
    /// </summary>
    public class PostmanWorkspaceInformation
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        /// <value>The Id.</value>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The Type.</value>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}