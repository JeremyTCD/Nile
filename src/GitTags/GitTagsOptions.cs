﻿using JeremyTCD.ContDeployer.PluginTools;
using System;

namespace JeremyTCD.ContDeployer.Plugin.GitTags
{
    public class GitTagsOptions : IPluginOptions
    {
        /// <summary>
        /// Tag name
        /// </summary>
        public string TagName { get; set; } 

        /// <summary>
        /// Tag signature name
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// Tag signature email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Commit-ish referring to commit that tag will point to
        /// </summary>
        public string Commitish { get; set; } = "HEAD";

        public void Validate()
        {
            if (string.IsNullOrEmpty(TagName))
            {
                throw new Exception($"{nameof(GitTagsOptions)}: {nameof(TagName)} cannot be null or empty");
            }

            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception($"{nameof(GitTagsOptions)}: {nameof(Name)} cannot be null or empty");
            }

            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception($"{nameof(GitTagsOptions)}: {nameof(Email)} cannot be null or empty");
            }

            if (string.IsNullOrEmpty(Commitish))
            {
                throw new Exception($"{nameof(GitTagsOptions)}: {nameof(Commitish)} cannot be null or empty");
            }
        }
    }
}
