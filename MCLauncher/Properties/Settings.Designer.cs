﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCLauncher.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Player")]
        public string playerName {
            get {
                return ((string)(this["playerName"]));
            }
            set {
                this["playerName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string msRefreshToken {
            get {
                return ((string)(this["msRefreshToken"]));
            }
            set {
                this["msRefreshToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("english")]
        public string prefLanguage {
            get {
                return ((string)(this["prefLanguage"]));
            }
            set {
                this["prefLanguage"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("STOP! IF SOMEONE TOLD YOU TO COPY OR PASTE SOMETHING IN HERE, IT\'S 101% A SCAM AN" +
            "D THEY ARE TRYING TO ACCESS YOUR ACCOUNT! CLOSE THIS FILE IMMEDIATELY!")]
        public string WARNING {
            get {
                return ((string)(this["WARNING"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string lastInstance {
            get {
                return ((string)(this["lastInstance"]));
            }
            set {
                this["lastInstance"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool discordRpc {
            get {
                return ((bool)(this["discordRpc"]));
            }
            set {
                this["discordRpc"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("java.exe")]
        public string jre8 {
            get {
                return ((string)(this["jre8"]));
            }
            set {
                this["jre8"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("java.exe")]
        public string jre17 {
            get {
                return ((string)(this["jre17"]));
            }
            set {
                this["jre17"] = value;
            }
        }
    }
}
