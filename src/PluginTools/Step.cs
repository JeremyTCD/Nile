﻿using System;
using Microsoft.Extensions.Configuration;

namespace JeremyTCD.ContDeployer.PluginTools
{
    /// <summary>
    /// A step in the pipeline. 
    /// </summary>
    public class Step<T> : IStep where T : IPlugin
    {

        public Step(IPluginOptions options)
        {
            PluginType = typeof(T);
            PluginOptions = options;
        }

        /// <summary>
        /// Name of plugin
        /// </summary>
        public Type PluginType { get; set; }

        /// <summary>
        /// Instantiated options
        /// </summary>
        public IPluginOptions PluginOptions { get; set; }
    }
}
