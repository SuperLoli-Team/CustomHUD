using CustomHUD.API.Features.Interfaces.Classes;
using Exiled.API.Features;
using RueI.Displays;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CustomHUD.API.Features.Interfaces
{
    public static class API
    {
        public static List<Display> DisplayList = new();
        public static Dictionary<Player, List<SLTElement>> CachedPlayerElements { get; set; } = new();
        public static List<SLTElement> CachedElements { get; set; } = new();

    }
}