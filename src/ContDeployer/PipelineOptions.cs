﻿using JeremyTCD.ContDeployer.PluginTools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JeremyTCD.ContDeployer
{
    public class PipelineOptions
    {
        public List<Step> Steps { get; set; } = new List<Step>();

        public void Validate()
        {
            if(Steps == null || !Steps.Any()) {
                throw new Exception($"{nameof(PipelineOptions)}: Pipeline steps required");
            }

            Step[] steps = Steps.ToArray();
            foreach(Step step in steps)
            {
                if (String.IsNullOrEmpty(step.PluginName))
                {
                    throw new Exception($"Pipeline step must have plugin name");
                }
            }
        }
    }
}
