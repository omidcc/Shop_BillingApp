﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smart.Dal.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source =  SmartTech\\SQLEXPRESS; User Id = sa; Password=can722count; Initial " +
            "Catalog = ShopBillingDB; ")]
        public string SQLConnectionString {
            get {
                return ((string)(this["SQLConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source =  NATIONALCOMPUTE\\SQLEXPRESS; User Id = sa; Password=hajigonj12#; In" +
            "itial Catalog = ShopBillingDb; ")]
        public string SQLConnectionStringHajiganj {
            get {
                return ((string)(this["SQLConnectionStringHajiganj"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source =  localhost\\sqlexpress; User Id = SUL; Password=Pass4App29; Initial " +
            "Catalog =ShopBillingBD; ")]
        public string SQLConnectionStringZia {
            get {
                return ((string)(this["SQLConnectionStringZia"]));
            }
        }
    }
}