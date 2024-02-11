// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Exiled.API.Interfaces;
using System.ComponentModel;

namespace No_SCP_049_2_suicide
{
    public class Translations : ITranslation
    {
        [Description("blabla")]
        public string BlablaMessage { get; set; } = "blabla";
    }
}
