﻿using JeremyTCD.DotNetCore.Utils;
using StructureMap;

namespace JeremyTCD.PipelinesCE.CommandLineApp
{
    public class CommandLineAppRegistry : Registry
    {
        public CommandLineAppRegistry()
        {
            IncludeRegistry<PipelinesCERegistry>();

            For<ICommandLineUtilsService>().Singleton().Use<CommandLineUtilsService>();

            For<RunCommand>().Singleton().Use<RunCommand>();
            For<RootCommand>().Singleton().Use<RootCommand>();
        }
    }
}