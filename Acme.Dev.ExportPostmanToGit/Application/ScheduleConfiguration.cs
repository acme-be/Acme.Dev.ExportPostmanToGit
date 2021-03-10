// <copyright file="ScheduleConfiguration.cs" company="Acme">
// Copyright (c) Acme. All rights reserved.
// </copyright>

namespace Acme.Dev.ExportPostmanToGit.Application
{
    /// <summary>
    /// Get the schedule configuration.
    /// </summary>
    public class ScheduleConfiguration
    {
        /// <summary>
        /// Gets or sets the interval in minutes for the worker to run.
        /// </summary>
        public int Interval { get; set; }
    }
}