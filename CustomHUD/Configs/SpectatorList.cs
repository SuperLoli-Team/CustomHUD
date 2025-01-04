using RueI.Extensions.HintBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RueI.Extensions.HintBuilding.HintBuilding;

namespace CustomHUD.Configs
{
    public class SpectatorList
    {
        public AlignStyle Align { get; private set; } = HintBuilding.AlignStyle.Right;
        public float position { get; set; } = 50;
    }
}
