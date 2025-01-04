using CustomHUD.API.Features.Interfaces.Classes;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using RueI.Displays;
using RueI.Elements.Delegates;
using RueI.Extensions.HintBuilding;
using RueI.Parsing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomHUD.Elements
{
    public class SpectratorList : SLTElement
    {
        public SpectratorList(GetContent contentGetter, float position) : base(contentGetter, position)
        {
            Position = TopRightPosition;
            ContentGetter = GetContent;
        }

        public override string Name { get; } = "the list of people who are watching you";
        public override string Description { get; } = "Shows a list of people who are watching you.";
        public override HintBuilding.AlignStyle Align { get; set; } = Plugin.StaticConfig.SpectatorList.Align;
        public float TopRightPosition = Plugin.StaticConfig.SpectatorList.position;

        public override string GetContent(DisplayCore core)
        {
            if (!Player.TryGet(core.Hub, out Player pl)) return "";

            StringBuilder sb = new StringBuilder()
                .SetSize(55, MeasurementUnit.Percentage)
                .SetLineHeight(750, MeasurementUnit.Percentage);

            if (!pl.CurrentSpectatingPlayers.Any()) return "";

            sb.Append($"You're being watched: (x{pl.CurrentSpectatingPlayers.Count()})").AppendLine();

            return sb.ToString();
        }
    }
}