// <copyright file="PostmanWorkspaceDetails.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Model
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represent a workspace details.
    /// </summary>
    public class PostmanWorkspaceDetails : PostmanWorkspaceInformation
    {
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The Description.</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Collections.
        /// </summary>
        /// <value>The Collections.</value>
        [JsonPropertyName("collections")]
        public List<PostmanCollectionInformation> Collections { get; set; }

        /// <summary>
        /// Gets or sets the Environments.
        /// </summary>
        /// <value>The Environments.</value>
        [JsonPropertyName("environments")]
        public List<PostmanEnvironmentInformation> Environments { get; set; }
    }
}