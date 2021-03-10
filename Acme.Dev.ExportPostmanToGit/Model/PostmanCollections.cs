// <copyright file="PostmanCollections.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Model
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represent a list of postman collections.
    /// </summary>
    public class PostmanCollections
    {
        /// <summary>
        /// Gets or sets the Collections.
        /// </summary>
        /// <value>The Collections.</value>
        [JsonPropertyName("collections")]
        public List<PostmanCollectionInformation> Collections { get; set; }
    }
}