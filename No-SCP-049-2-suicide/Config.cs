// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Exiled.API.Interfaces;
using System.ComponentModel;

namespace No_SCP_049_2_suicide
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin should be enabled. Default: true")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not debug logs should be shown. Default: false")]
        public bool Debug { get; set; } = true;
    }
}
