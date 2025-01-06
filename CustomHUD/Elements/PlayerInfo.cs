using CustomHUD.API.Features.Interfaces.Classes;
using Exiled.API.Features;
using PlayerRoles;
using RueI.Displays;
using RueI.Elements.Delegates;
using RueI.Extensions.HintBuilding;
using RueI.Parsing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomHUD.Elements
{
    public class PlayerInfo : SLTElement
    {
        public PlayerInfo(GetContent contentGetter, float position) : base(contentGetter, position)
        {
            Position = BasePosition;
            ContentGetter = GetContent;
        }

        public override string Name { get; } = "Info of player";
        public override string Description { get; } = "Shows a Info of player";
        public override HintBuilding.AlignStyle Align { get; set; } = Plugin.StaticConfig.PlayerInfo.Align;
        public float BasePosition = Plugin.StaticConfig.PlayerInfo.position;
        public const float PosNull = 15;

        public override string GetContent(DisplayCore core)
        {
            if (!Player.TryGet(core.Hub, out Player pl)) return "";

            StringBuilder sb = new StringBuilder()
                .SetSize(55, MeasurementUnit.Percentage)
                .SetLineHeight(750, MeasurementUnit.Percentage);

            if (!pl.IsAlive) return "";

            sb.Append($"Your name: {pl.DisplayNickname}")
                .AddLinebreak()
                .Append($"Your Role: <color={pl.Role.Color.ToHex()}> {Plugin.StaticConfig.PlayerInfo.roleNames[pl.Role.Type]} </color>")
                .AppendLine();
            return sb.ToString();
        }
    }
}