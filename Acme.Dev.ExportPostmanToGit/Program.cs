// <copyright file="Program.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Acme.Dev.ExportPostmanToGit.Application;
    using Acme.Dev.ExportPostmanToGit.Workers;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Main class of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        /// <param name="args">Startup parameters.</param>
        private static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, configBuilder) =>
                {
                    configBuilder.AddEnvironmentVariables();
                    configBuilder.SetBasePath(Directory.GetCurrentDirectory());
                    configBuilder.AddJsonFile("appsettings.json", true);
                    configBuilder.AddJsonFile(
                        $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                        true);
                })
                .ConfigureLogging((hostContext, configLogging) =>
                {
                    configLogging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    configLogging.AddConsole();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(_ => hostContext.Configuration.GetSection("Schedule").Get<ScheduleConfiguration>());
                    services.AddSingleton(_ => hostContext.Configuration.GetSection("Postman").Get<PostmanConfiguration>());

                    services.AddScoped<ExportPostman>();
                    services.AddScoped<IHostedService, ExportPostmanAccountService>();
                });

            await hostBuilder.RunConsoleAsync();
        }
    }
}