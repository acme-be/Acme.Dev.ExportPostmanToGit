// <copyright file="ExportPostmanAccountService.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Hosted service to export the collection from postman to a local directory.
    /// </summary>
    public class ExportPostmanAccountService : IHostedService
    {
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportPostmanAccountService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ExportPostmanAccountService(ILogger<ExportPostmanAccountService> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.Log(LogLevel.Information, $"{nameof(ExportPostmanAccountService)} is starting");
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.Log(LogLevel.Information, $"{nameof(ExportPostmanAccountService)} is stopping");
            return Task.CompletedTask;
        }
    }
}