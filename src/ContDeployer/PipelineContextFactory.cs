﻿using JeremyTCD.ContDeployer.PluginTools;
using LibGit2Sharp;
using System.Collections.Generic;

namespace JeremyTCD.ContDeployer
{
    public class PipelineContextFactory
    {
        private IProcessManager _processManager { get; }
        private IHttpManager _httpManager { get; }
        private IRepository _repository { get; }
        private LinkedList<Step> _steps { get; set; }

        public PipelineContextFactory(IHttpManager httpManager, IProcessManager processManager, IRepository repository)
        {
            _httpManager = httpManager;
            _processManager = processManager;
            _repository = repository;
        }

        public PipelineContextFactory AddSteps(List<Step> steps)
        {
            // Use linked list since steps will be added to and removed from start of list
            _steps = new LinkedList<Step>(steps);

            return this;
        }

        public PipelineContext Build()
        {
            PipelineContext context = new PipelineContext
            {
                HttpManager = _httpManager,
                ProcessManager = _processManager,
                Repository = _repository,
                SharedData = new Dictionary<string, object>(),
                Steps = _steps
            };

            return context;
        }
    }
}
