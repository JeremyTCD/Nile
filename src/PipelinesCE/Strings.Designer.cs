﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JeremyTCD.PipelinesCE {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("JeremyTCD.PipelinesCE.Strings", typeof(Strings).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple pipeline factories found:\n{0}.
        /// </summary>
        public static string Exception_MultiplePipelineFactories {
            get {
                return ResourceManager.GetString("Exception_MultiplePipelineFactories", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No pipeline factories .
        /// </summary>
        public static string Exception_NoPipelineFactories {
            get {
                return ResourceManager.GetString("Exception_NoPipelineFactories", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No pipeline factory builds a pipeline with name &quot;{0}&quot;.
        /// </summary>
        public static string Exception_NoPipelineFactory {
            get {
                return ResourceManager.GetString("Exception_NoPipelineFactory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to === Pipeline &quot;{0}&quot; complete ===.
        /// </summary>
        public static string PipelineComplete {
            get {
                return ResourceManager.GetString("PipelineComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /t:restore,build /p:Configuration=Release.
        /// </summary>
        public static string PipelinesCEProjectMSBuildSwitches {
            get {
                return ResourceManager.GetString("PipelinesCEProjectMSBuildSwitches", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to == Plugin &quot;{0}&quot; complete ==.
        /// </summary>
        public static string PluginComplete {
            get {
                return ResourceManager.GetString("PluginComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to === Running pipeline &quot;{0}&quot; ===.
        /// </summary>
        public static string RunningPipeline {
            get {
                return ResourceManager.GetString("RunningPipeline", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to == Running plugin &quot;{0}&quot; ==.
        /// </summary>
        public static string RunningPlugin {
            get {
                return ResourceManager.GetString("RunningPlugin", resourceCulture);
            }
        }
    }
}
