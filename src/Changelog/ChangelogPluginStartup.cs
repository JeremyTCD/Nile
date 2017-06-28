﻿using JeremyTCD.PipelinesCE.PluginAndConfigTools;
using JeremyTCD.DotNetCore.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace JeremyTCD.PipelinesCE.Plugin.Changelog
{
    public class ChangelogPluginStartup : IPluginStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IChangelogFactory, ChangelogFactory>();
            services.AddSingleton<IFileService, FileService>();
        }
    }
}
