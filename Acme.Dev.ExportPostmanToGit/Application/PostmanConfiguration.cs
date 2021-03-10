// <copyright file="PostmanConfiguration.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Application
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represent the configuration of postman.
    /// </summary>
    public class PostmanConfiguration
    {
        /// <summary>
        /// Gets or sets the ApiKey.
        /// </summary>
        /// <value>The ApiKey.</value>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether git command must be called.
        /// </summary>
        /// <value>The EnableGit.</value>
        public bool EnableGit { get; set; }

        /// <summary>
        /// Gets or sets the LocalDirectory.
        /// </summary>
        /// <value>The LocalDirectory.</value>
        public string LocalDirectory { get; set; }
    }
}