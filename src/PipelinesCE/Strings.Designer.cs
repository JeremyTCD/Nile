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
        ///   Looks up a localized string similar to Multiple pipeline factories found, please specify one:\n{0}.
        /// </summary>
        public static string Exception_MultiplePipelineFactories {
            get {
                return ResourceManager.GetString("Exception_MultiplePipelineFactories", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple pipeline factories build a pipeline with name &quot;{0}&quot;:\n{1}.
        /// </summary>
        public static string Exception_MultiplePipelineFactoriesWithSameName {
            get {
                return ResourceManager.GetString("Exception_MultiplePipelineFactoriesWithSameName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No container for plugin type with name &quot;{0}&quot;.
        /// </summary>
        public static string Exception_NoContainerForPluginType {
            get {
                return ResourceManager.GetString("Exception_NoContainerForPluginType", resourceCulture);
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
        ///   Looks up a localized string similar to No service for plugin type with name &quot;{0}&quot;.
        /// </summary>
        public static string Exception_NoServiceForPluginType {
            get {
                return ResourceManager.GetString("Exception_NoServiceForPluginType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type &quot;{0}&quot; does not implement &quot;{1}&quot;.
        /// </summary>
        public static string Exception_TypeDoesNotImplement {
            get {
                return ResourceManager.GetString("Exception_TypeDoesNotImplement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Building Pipeline &quot;{0}&quot;.
        /// </summary>
        public static string Log_BuildingPipeline {
            get {
                return ResourceManager.GetString("Log_BuildingPipeline", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Building PipelinesCE project &quot;{0}&quot;.
        /// </summary>
        public static string Log_BuildingPipelinesCEProject {
            get {
                return ResourceManager.GetString("Log_BuildingPipelinesCEProject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Building Plugin of Type &quot;{0}&quot;.
        /// </summary>
        public static string Log_BuildingPlugin {
            get {
                return ResourceManager.GetString("Log_BuildingPlugin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Configuring IOC container for plugin type &quot;{0}&quot;.
        /// </summary>
        public static string Log_ConfiguringPluginContainer {
            get {
                return ResourceManager.GetString("Log_ConfiguringPluginContainer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Configuring services for plugin type &quot;{0}&quot; using plugin startup type &quot;{1}&quot;.
        /// </summary>
        public static string Log_ConfiguringPluginServices {
            get {
                return ResourceManager.GetString("Log_ConfiguringPluginServices", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to === Initializing PipelinesCE ===.
        /// </summary>
        public static string Log_InitializingPipelinesCE {
            get {
                return ResourceManager.GetString("Log_InitializingPipelinesCE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to === Pipeline &quot;{0}&quot; complete ===.
        /// </summary>
        public static string Log_PipelineComplete {
            get {
                return ResourceManager.GetString("Log_PipelineComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PipelinesCE project &quot;{0}&quot; successfully built.
        /// </summary>
        public static string Log_PipelinesCEProjectSuccessfullyBuilt {
            get {
                return ResourceManager.GetString("Log_PipelinesCEProjectSuccessfullyBuilt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to === PipelinesCE successfully initialized ===.
        /// </summary>
        public static string Log_PipelinesCESuccessfullyInitialized {
            get {
                return ResourceManager.GetString("Log_PipelinesCESuccessfullyInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pipeline &quot;{0}&quot; successfully built.
        /// </summary>
        public static string Log_PipelineSuccessfullyBuilt {
            get {
                return ResourceManager.GetString("Log_PipelineSuccessfullyBuilt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to == Plugin &quot;{0}&quot; complete ==.
        /// </summary>
        public static string Log_PluginComplete {
            get {
                return ResourceManager.GetString("Log_PluginComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IOC container for plugin type &quot;{0}&quot; successfully configured.
        /// </summary>
        public static string Log_PluginContainerSuccessfullyConfigured {
            get {
                return ResourceManager.GetString("Log_PluginContainerSuccessfullyConfigured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Default Pipeline resolved to &quot;{0}&quot;.
        /// </summary>
        public static string Log_ResolvedDefaultPipeline {
            get {
                return ResourceManager.GetString("Log_ResolvedDefaultPipeline", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Retrieving PipelineFactory for pipeline &quot;{0}&quot;.
        /// </summary>
        public static string Log_RetrievingPipelineFactory {
            get {
                return ResourceManager.GetString("Log_RetrievingPipelineFactory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to === Running pipeline &quot;{0}&quot; ===.
        /// </summary>
        public static string Log_RunningPipeline {
            get {
                return ResourceManager.GetString("Log_RunningPipeline", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to == Running plugin &quot;{0}&quot; ==.
        /// </summary>
        public static string Log_RunningPlugin {
            get {
                return ResourceManager.GetString("Log_RunningPlugin", resourceCulture);
            }
        }
    }
}
