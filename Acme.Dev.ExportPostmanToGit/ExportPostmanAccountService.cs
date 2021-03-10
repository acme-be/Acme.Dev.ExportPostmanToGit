// <copyright file="ExportPostmanAccountService.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Acme.Dev.ExportPostmanToGit.Application;
    using Acme.Dev.ExportPostmanToGit.Workers;

    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Hosted service to export the collection from postman to a local directory.
    /// </summary>
    public class ExportPostmanAccountService : IHostedService, IDisposable
    {
        private readonly ILogger logger;
        private readonly ScheduleConfiguration scheduleConfiguration;
        private readonly ExportPostman exportPostman;
        private Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportPostmanAccountService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="scheduleConfiguration">The configuration of the scheduler.</param>
        /// <param name="exportPostman">Worker that export postman to local.</param>
        public ExportPostmanAccountService(ILogger<ExportPostmanAccountService> logger, ScheduleConfiguration scheduleConfiguration, ExportPostman exportPostman)
        {
            this.logger = logger;
            this.scheduleConfiguration = scheduleConfiguration;
            this.exportPostman = exportPostman;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.timer?.Dispose();
        }

        /// <inheritdoc />
        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation($"{nameof(ExportPostmanAccountService)} is starting");

            this.timer = new Timer(this.DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(this.scheduleConfiguration.Interval));

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation($"{nameof(ExportPostmanAccountService)} is stopping");

            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            this.logger.LogDebug("Timer is ticking");
            this.exportPostman.Run();
        }
    }
}