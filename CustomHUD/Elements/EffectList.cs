using CustomHUD.API.Features.Interfaces.Classes;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using RueI.Displays;
using RueI.Elements.Delegates;
using RueI.Extensions.HintBuilding;
using RueI.Parsing.Enums;
using System.Linq;
using System.Text;

namespace CustomHUD.Elements
{
    public class EffectList : SLTElement
    {
        public EffectList(GetContent contentGetter, float position) : base(contentGetter, position)
        {
            Position = PositionHint;
            ContentGetter = GetContent;
        }
        public override string Name { get; } = "Effects";
        public override string Description { get; } = "Your effects";
        public override HintBuilding.AlignStyle Align { get; set; } = Plugin.StaticConfig.effectList.Align;
        public float PositionHint = Plugin.StaticConfig.effectList.position;
        public override string GetContent(DisplayCore core)
        {
            if (!Player.TryGet(core.Hub, out Player pl)) return "";

            StringBuilder sb = new StringBuilder()
                .SetAlignment(Align)
                .SetSize(45, MeasurementUnit.Percentage)
                .SetLineHeight(75, MeasurementUnit.Percentage);

            if (!pl.ActiveEffects.Any()) return "";

            sb.AppendLine("Your active effects:");

            for (int i = 0; i < 4; i++)
            {
                var element = pl.ActiveEffects.ElementAtOrDefault(i);

                if (element != null) sb.AppendLine($"<color={GetEffectType(element.GetEffectType())}>{element.name}</color> ({(element.TimeLeft == 0 ? "forever" : $"{element.TimeLeft} с.")} | {element.Intensity}x)");
                else sb.AppendLine();
            }

            if (pl.ActiveEffects.Count() > 4) sb.AppendLine($"and also {pl.ActiveEffects.Count() - 4}");
            else sb.AppendLine();

            return sb.ToString();
        }

        public string GetEffectType(EffectType effectType)
        {
            if (effectType.IsPositive() && effectType.IsNegative()) return "purple";

            if (effectType.IsPositive()) return "green";

            if (effectType.IsNegative()) return "red";

            return "white";
        }
    }
}