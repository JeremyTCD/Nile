﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JeremyTCD.ContDeployer.PluginTools
{
    public interface IPlugin
    {
        IDictionary<string, Object> DefaultConfig { get; set; }

        void Run(IDictionary<string, object> config, PipelineContext context, LinkedList<PipelineStep> steps);
    }
}
