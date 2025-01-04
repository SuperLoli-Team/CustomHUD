using CustomHUD.API.Features.Interfaces;
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
    public class ServerName : SLTElement
    {
        public ServerName(GetContent contentGetter, float position) : base(contentGetter, position)
        {
            Position = BasePosition;
            ContentGetter = GetContent;
        }
        public override string Name { get; } = "Server Name";
        public override string Description { get; } = "Server Name";
        public override HintBuilding.AlignStyle Align { get; set; } = Plugin.StaticConfig.ServerName.Align;
        public float BasePosition = Plugin.StaticConfig.ServerName.position;
        public override string GetContent(DisplayCore core)
        {
            if (!Player.TryGet(core.Hub, out Player pl)) return "";

            StringBuilder sb = new StringBuilder()
            .SetAlignment(Align)
            .SetSize(55, MeasurementUnit.Percentage)
            .SetLineHeight(85, MeasurementUnit.Percentage);
                sb.AppendLine();

            sb.AppendLine($"{Plugin.StaticConfig.ServerName.NameOfProject ?? "My cool project"} {Plugin.StaticConfig.ServerName.ModeOfServer} {Plugin.StaticConfig.ServerName.TimeData} | {Plugin.StaticConfig.ServerName.TimeZone}");

            return sb.ToString();
        }
    }
}