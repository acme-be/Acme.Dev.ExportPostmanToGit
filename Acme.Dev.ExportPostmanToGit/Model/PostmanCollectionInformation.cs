// <copyright file="PostmanCollectionInformation.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represent base informations of a postman collection.
    /// </summary>
    public class PostmanCollectionInformation
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
        /// Gets or sets the Owner.
        /// </summary>
        /// <value>The Owner.</value>
        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the Uid.
        /// </summary>
        /// <value>The Uid.</value>
        [JsonPropertyName("uid")]
        public string Uid { get; set; }
    }
}