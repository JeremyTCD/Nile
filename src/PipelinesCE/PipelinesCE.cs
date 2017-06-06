﻿using JeremyTCD.DotNetCore.Utils;
using JeremyTCD.PipelinesCE.PluginTools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JeremyTCD.PipelinesCE
{
    public class PipelinesCE
    {
        private IAssemblyService _assemblyService { get; }
        private IPipelineRunner _pipelineRunner { get; }
        private ILogger<PipelinesCE> _logger { get; }
        private IPathService _pathService { get; }
        private IDirectoryService _directoryService { get; }
        private IMSBuildService _msBuildService { get; }
        private IActivatorService _activatorService { get; }
        private IContainer _mainContainer { get; }

        public PipelinesCE(IActivatorService activatorService,
            IAssemblyService assemblyService,
            IPathService pathService,
            IDirectoryService directoryService,
            IMSBuildService msBuildService,
            IPipelineRunner pipelineRunner,
            IContainer mainContainer,
            ILogger<PipelinesCE> logger)
        {
            _mainContainer = mainContainer;
            _msBuildService = msBuildService;
            _pathService = pathService;
            _assemblyService = assemblyService;
            _pipelineRunner = pipelineRunner;
            _directoryService = directoryService;
            _logger = logger;
            _activatorService = activatorService;
        }

        /// <summary>
        /// Runs pipeline specified by <see cref="PipelineOptions.Pipeline"/>
        /// </summary>
        /// <param name="pipelineOptions">
        /// Options provided by caller. Typically arguments to the command line application.
        /// </param>
        public virtual void Run(PipelineOptions pipelineOptions)
        {
            string projectFile = _pathService.GetAbsolutePath(pipelineOptions.Project);
            string projectDirectory = _directoryService.GetParent(projectFile).FullName;

            // Build project
            _msBuildService.Build(projectFile, Strings.PipelinesCEProjectMSBuildSwitches);

            // Load assemblies
            IEnumerable<Assembly> assemblies = _assemblyService.
                LoadAssembliesInDir(Path.Combine(projectDirectory, "bin/Release/netcoreapp1.1"), true);

            // Create plugin containers
            CreatePluginContainers(assemblies);

            // Create pipeline
            IPipelineFactory factory = GetPipelineFactory(assemblies, pipelineOptions.Pipeline);
            Pipeline pipeline = factory.CreatePipeline();
            pipeline.Options = pipelineOptions.Combine(pipeline.Options);

            _pipelineRunner.Run(pipeline);
        }

        private void CreatePluginContainers(IEnumerable<Assembly> assemblies)
        {
            List<Type> pluginTypes = _assemblyService.GetAssignableTypes(assemblies, typeof(IPlugin)).ToList();
            IDictionary<string, Type> pluginStartupTypes = _assemblyService.GetAssignableTypes(assemblies, typeof(IPluginStartup)).ToDictionary(t => t.Name);
            foreach (Type pluginType in pluginTypes)
            {
                // Configure services
                ServiceCollection services = new ServiceCollection();
                pluginStartupTypes.TryGetValue($"{pluginType.Name}Startup", out Type pluginStartupType);
                if (pluginStartupType != null)
                {
                    IPluginStartup pluginStartup = (IPluginStartup)_activatorService.CreateInstance(pluginStartupType);
                    pluginStartup.ConfigureServices(services);
                }
                services.AddTransient(pluginType);

                _mainContainer.Configure(configurationExpression =>
                {
                    configurationExpression.Profile(pluginType.Name, registry =>
                    {
                        ((Registry)registry).Populate(services);
                    });
                });
            }
        }

        /// <summary>
        /// Gets <see cref="IPipelineFactory"/> from project assemblies that creates a pipeline with name 
        /// <paramref name="pipeline"/>. If <paramref name="pipeline"/> is null and there is only one <see cref="IPipelineFactory"/> 
        /// implementation, returns an instance of the sole implementation.
        /// </summary>
        /// <param name="projectFile"></param>
        /// <param name="pipeline"></param>
        /// <returns>
        /// <see cref="IPipelineFactory"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if project does not contain any <see cref="IPipelineFactory"/> implementations
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <paramref name="pipeline"/> is null and there are multiple pipeline factories
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if no <see cref="IPipelineFactory"/> produces a pipeline with name <paramref name="pipeline"/>
        /// </exception>
        private IPipelineFactory GetPipelineFactory(IEnumerable<Assembly> assemblies, string pipeline)
        {
            // TODO what if framework version changes? can a wildcard be used? what if project builds for multiple frameworks?
            IDictionary<string, Type> pipelineFactoryTypes = _assemblyService.
                GetAssignableTypes(assemblies, typeof(IPipelineFactory)).
                ToDictionary(t => t.Name.Replace("PipelineFactory", "").ToLowerInvariant());

            if (pipelineFactoryTypes.Count == 0)
            {
                throw new InvalidOperationException(Strings.NoPipelineFactories);
            }

            Type pipelineFactoryType;
            if (pipeline == null)
            {
                if (pipelineFactoryTypes.Count == 1)
                {
                    pipelineFactoryType = pipelineFactoryTypes.First().Value;
                }
                else
                {
                    throw new InvalidOperationException(string.Format(Strings.MultiplePipelineFactories,
                        string.Join("\n", pipelineFactoryTypes.Values)));
                }
            }
            else
            {
                pipelineFactoryTypes.TryGetValue(pipeline.ToLowerInvariant(), out pipelineFactoryType);
                if (pipelineFactoryType == null)
                {
                    throw new InvalidOperationException(string.Format(Strings.NoPipelineFactory, pipeline));
                }
            }

            IPipelineFactory factory = (IPipelineFactory)_activatorService.CreateInstance(pipelineFactoryType);
            return factory;
        }
    }
}
