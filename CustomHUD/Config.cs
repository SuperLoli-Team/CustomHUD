using CustomHUD.Configs;
using Exiled.API.Interfaces;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHUD
{
    public class Config : IConfig
    {
        [Description("Whether this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Whether debug messages should be shown in the console.")]
        public bool Debug { get; set; } = false;
        public EffectList effectList { get; set; } = new();
        public ServerName ServerName { get; set; } = new();
        public PlayerInfo PlayerInfo { get; set; } = new();
        public SpectatorList SpectatorList { get; set; } = new();
    }
}