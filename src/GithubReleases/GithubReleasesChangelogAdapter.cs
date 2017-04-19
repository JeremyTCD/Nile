﻿using JeremyTCD.ContDeployer.Plugin.ChangelogGenerator;
using JeremyTCD.ContDeployer.PluginTools;
using Microsoft.Extensions.Logging;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JeremyTCD.ContDeployer.Plugin.GithubReleases
{
    public class GithubReleasesChangelogAdapter : IPlugin
    {
        private PipelineContext _pipelineContext { get; set; }
        private GithubReleasesChangelogAdapterOptions _options { get; set; }

        /// <summary>
        /// Compares <see cref="Changelog"/> and github releases. Creates releases for versions with no corresponding 
        /// release. Edits releases for versions that have been modified.
        /// </summary>
        /// <param name="sharedData"></param>
        /// <param name="steps"></param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <see cref="StepContext.Options"/> is null
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <see cref="PipelineContext.SharedData"/> does not contain <see cref="Changelog"/> instance
        /// </exception>
        public void Run(PipelineContext pipelineContext, StepContext stepContext)
        {
            _options = stepContext.Options as GithubReleasesChangelogAdapterOptions;

            if (_options == null)
            {
                throw new InvalidOperationException($"{nameof(GithubReleasesChangelogAdapterOptions)} required");
            }

            _pipelineContext = pipelineContext;

            pipelineContext.SharedData.TryGetValue(nameof(Changelog), out object changelogObject);
            Changelog changelog = changelogObject as Changelog;
            if (changelog == null)
            {
                throw new InvalidOperationException($"No {nameof(Changelog)} in {nameof(pipelineContext.SharedData)}");
            }

            List<ChangelogGenerator.Version> versions = changelog.Versions.ToList();

            Dictionary<string, Release> releases = GetGithubReleases();

            GithubReleasesOptions githubReleasesOptions = new GithubReleasesOptions
            {
                Owner = _options.Owner,
                Repository = _options.Repository,
                Token = _options.Token
            };

            foreach (ChangelogGenerator.Version version in versions)
            {
                string name = version.SemVersion.ToString();

                releases.TryGetValue(name, out Release release);

                if (release == null)
                {
                    githubReleasesOptions.NewReleases.Add(new NewRelease(name)
                    {
                        Body = version.Notes,
                        Name = name,
                        Draft = false,
                        Prerelease = name.Contains('-'),
                        TargetCommitish = _options.Commitish // Ignored by github api if tag already exists, otherwise creates a tag pointing to commitish
                    });

                    stepContext.
                        Logger.
                        LogInformation($"Version \"{name}\" has no corresponding github release");
                }
                else if (release.Body != version.Notes)
                {
                    // GithubReleases with edit options
                    githubReleasesOptions.ReleaseUpdates.Add(new ReleaseUpdate()
                    {
                        Body = version.Notes,
                        Name = name,
                        Draft = false,
                        Prerelease = name.Contains('-'),
                        TargetCommitish = _options.Commitish
                    });

                    stepContext.
                        Logger.
                        LogInformation($"Version \"{name}\" has been updated");
                }
            }

            if (githubReleasesOptions.NewReleases.Count > 0 || githubReleasesOptions.ReleaseUpdates.Count > 0)
            {
                Step githubReleasesStep = new Step(nameof(GithubReleases), githubReleasesOptions);
                pipelineContext.Steps.AddFirst(githubReleasesStep);

                stepContext.
                    Logger.
                    LogInformation($"Added {nameof(GithubReleases)} step");
            }
            else
            {
                stepContext.
                    Logger.
                    LogInformation("Github releases consistent with changelog");
            }
        }

        /// <summary>
        /// Retrieves github <see cref="Release"/>s for specified repository
        /// </summary>
        /// <returns>
        /// <see cref="Dictionary{String, Release}"/>
        /// </returns>
        private Dictionary<string, Release> GetGithubReleases()
        {
            // TODO inject this, expose iservicecollection and iserviceprovider in pipelinecontext,
            // register services for plugins.
            GitHubClient client = new GitHubClient(new ProductHeaderValue(nameof(ContDeployer)));
            Credentials credentials = new Credentials(_options.Token);
            client.Credentials = credentials;

            return client.
                Repository.
                Release.
                GetAll(_options.Owner, _options.Repository).
                Result.ToDictionary(release => release.TagName);
        }
    }
}