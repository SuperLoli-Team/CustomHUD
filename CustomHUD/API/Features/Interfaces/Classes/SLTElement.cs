using RueI.Displays;
using RueI.Elements.Delegates;
using RueI.Elements;
using RueI.Extensions.HintBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHUD.API.Features.Interfaces.Classes
{
    public class SLTElement : DynamicElement
    {
        public SLTElement(GetContent contentGetter, float position) : base(contentGetter, position)
        {
        }

        public virtual string Name { get; } = string.Empty;
        public virtual string Description { get; } = string.Empty;
        public virtual bool CanBeTurnedDown { get; } = true;
        public virtual HintBuilding.AlignStyle Align { get; set; } = default;
        public virtual string GetContent(DisplayCore hub)
        {
            return string.Empty;
        }
    }
}