﻿using System;
using JeremyTCD.PipelinesCE.PluginAndConfigTools;

namespace JeremyTCD.PipelinesCE.Plugin.Configuration
{
    public class ConfigurationPluginOptions : IPluginOptions
    {
        public virtual PipelineOptions PipelineOptions {get;set;}

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
