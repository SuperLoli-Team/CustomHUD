using RueI.Extensions.HintBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RueI.Extensions.HintBuilding.HintBuilding;

namespace CustomHUD.Configs
{
    public class ServerName
    {
        public AlignStyle Align { get; private set; } = HintBuilding.AlignStyle.Center;
        public float position { get; set; } = 15;
        public string NameOfProject { get; set; } = "<color=#c85be3> My cool project!!! </color>";
        public string ModeOfServer { get; set; } = "CLASSIC";
        public string TimeData { get; set; } = DateTime.Now.ToShortTimeString();
        public string TimeZone { get; set; } = "MSK";
    }
}
