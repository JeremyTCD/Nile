﻿using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace JeremyTCD.DevOps.ContDeployer
{
    [Export(typeof(IPlugin))]
    public class MetadataFactoryPlugin : IPlugin
    {
        public void Execute()
        {
        }
    }
}
