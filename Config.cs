using Exiled.API.Interfaces;
using System.ComponentModel;

namespace RandomItems
{
    public sealed class Config : IConfig
    {
        [Description("Whether the plugin is enabled or not.")]
        public bool IsEnabled { get; set; } = true;
    }
}
