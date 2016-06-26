﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RockSatGraphIt.Properties {
    using System;
    
    
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RockSatGraphIt.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Alert.
        /// </summary>
        internal static string AlertTitle {
            get {
                return ResourceManager.GetString("AlertTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Directory does not exist... Create?.
        /// </summary>
        internal static string DirectoryDoesntExist {
            get {
                return ResourceManager.GetString("DirectoryDoesntExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All fields must be filled out... Sorry!.
        /// </summary>
        internal static string EmptyFieldsError {
            get {
                return ResourceManager.GetString("EmptyFieldsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File must end in a .csv extension... sorry!.
        /// </summary>
        internal static string InvalidFileExtension {
            get {
                return ResourceManager.GetString("InvalidFileExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid graph type....
        /// </summary>
        internal static string InvalidGraphType {
            get {
                return ResourceManager.GetString("InvalidGraphType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Letters aren&apos;t numbers, silly....
        /// </summary>
        internal static string InvalidNumber {
            get {
                return ResourceManager.GetString("InvalidNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid output type....
        /// </summary>
        internal static string InvalidOutputType {
            get {
                return ResourceManager.GetString("InvalidOutputType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start time must be greater than 0....
        /// </summary>
        internal static string InvalidStartTime {
            get {
                return ResourceManager.GetString("InvalidStartTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MissionPatch {
            get {
                object obj = ResourceManager.GetObject("MissionPatch", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon nasa {
            get {
                object obj = ResourceManager.GetObject("nasa", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Upper bounds must exceed lower bounds...
        /// </summary>
        internal static string NumericalBoundsError {
            get {
                return ResourceManager.GetString("NumericalBoundsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] R {
            get {
                object obj = ResourceManager.GetObject("R", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ##RockSat-C 2016 Graphing Utility
        ///##Author: David Colclazier
        ///##GPL V2
        ///##RScript.exe source is available at https://github.com/wch/r-source
        ///##To Run, tweak the tweakables, select all (Ctrl-A) and press (Ctrl-R) within RGui.
        ///##Download RGui from... INSERT LINK
        ///##RScript.exe is licensed by
        ///
        ///#clear variables from previous session (dev-use only I think)
        ///rm(list = setdiff(ls(), lsf.str()))
        ///
        ///cat(&quot;Beginning RockSat Graph Creation Execution\n&quot;);
        ///
        ///#TWEAKABLE VARIABLES - INPUT
        ///fileName = &quot;__Filename__&quot;   [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RScript {
            get {
                return ResourceManager.GetString("RScript", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error generating R script....
        /// </summary>
        internal static string ScriptGenerationError {
            get {
                return ResourceManager.GetString("ScriptGenerationError", resourceCulture);
            }
        }
    }
}
