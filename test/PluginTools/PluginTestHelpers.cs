﻿using LibGit2Sharp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace JeremyTCD.ContDeployer.PluginTools.Tests
{
    /// <summary>
    /// Helper functions for testing plugins
    /// </summary>
    public class PluginTestHelpers
    {
        /// <summary>
        /// Creates a <see cref="PipelineContext"/> instance. Uses empty structures and defaults for dependencies and
        /// properties.
        /// </summary>
        /// <returns></returns>
        public static PipelineContext CreatePipelineContext(bool dryRun = false)
        {
            Dictionary<string, object> sharedData = new Dictionary<string, object>();
            LinkedList<Step> steps = new LinkedList<Step>();
            Mock<ILogger<ProcessManager>> mockLogger = new Mock<ILogger<ProcessManager>>();
            Mock<IOptions<SharedOptions>> mockOptions = new Mock<IOptions<SharedOptions>>();
            mockOptions.Setup(o => o.Value).Returns(new SharedOptions
            {
                DryRun = dryRun
            });
            ProcessManager processManager = new ProcessManager(mockLogger.Object, mockOptions.Object);
            Repository repository = new Repository(Directory.GetCurrentDirectory());

            return new PipelineContext
            {
                Repository = repository,
                ProcessManager = processManager,
                SharedData = sharedData,
                Steps = steps
            };
        }

        /// <summary>
        /// Creates a <see cref="StepContext"/> instance. 
        /// </summary>
        /// <param name="pluginOptions"></param>
        /// <returns></returns>
        public static StepContext CreateStepContext(IPluginOptions pluginOptions = null)
        {
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            return new StepContext
            {
                Options = pluginOptions,
                Logger = mockLogger.Object
            };
        }
    }
}