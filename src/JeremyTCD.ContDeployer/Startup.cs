﻿using JeremyTCD.DotNetCore.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JeremyTCD.ContDeployer
{
    class Startup
    {
        public static IConfigurationRoot _configurationRoot { get; set; }

        public Startup()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("cd.json", false);
            _configurationRoot = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.
                AddLogging().
                AddOptions();

            services.
                AddSingleton<IAssemblyService, AssemblyService>();

            services.
                AddSingleton<PipelineContextFactory>().
                // PipelineContext service
                AddSingleton(provider => provider.GetRequiredService<PipelineContextFactory>().Build()).
                AddSingleton<Pipeline>();

            services.Configure<PipelineOptions>(_configurationRoot.GetSection("Pipeline"));
        }

        public void Configure(ILoggerFactory loggerFactory)
        {
            loggerFactory.
                AddConsole((LogLevel)Enum.Parse(typeof(LogLevel), _configurationRoot["Logging:LogLevel:Console"])).
                AddDebug((LogLevel)Enum.Parse(typeof(LogLevel), _configurationRoot["Logging:LogLevel:Debug"]));
        }
    }
}