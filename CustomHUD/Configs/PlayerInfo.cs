using PlayerRoles;
using RueI.Extensions.HintBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RueI.Extensions.HintBuilding.HintBuilding;

namespace CustomHUD.Configs
{
    public class PlayerInfo
    {
        public AlignStyle Align { get; private set; } = HintBuilding.AlignStyle.Left;
        public float position { get; set; } = 15;
        public Dictionary<RoleTypeId, string> roleNames { get; set; } = new()
        {
            { RoleTypeId.ClassD, "Class D" },
            { RoleTypeId.Scientist, "Scientist" },
            { RoleTypeId.FacilityGuard, "Facility Guard" },
            { RoleTypeId.NtfPrivate, "Ntf Private" },
            { RoleTypeId.NtfSergeant, "Ntf Sergeant" },
            { RoleTypeId.NtfCaptain, "Ntf Captain" },
            { RoleTypeId.NtfSpecialist, "Ntf Specialist" },
            { RoleTypeId.ChaosConscript, "Chaos Conscript" },
            { RoleTypeId.ChaosRifleman, "Chaos Rifleman" },
            { RoleTypeId.ChaosRepressor, "ChaosRepressor" },
            { RoleTypeId.ChaosMarauder, "Chaos Marauder" },
            { RoleTypeId.Scp049, "SCP-049" },
            { RoleTypeId.Scp0492, "SCP-049-2" },
            { RoleTypeId.Scp079, "SCP-079" },
            { RoleTypeId.Scp096, "SCP-096" },
            { RoleTypeId.Scp106, "SCP-106" },
            { RoleTypeId.Scp173, "SCP-173" },
            { RoleTypeId.Scp939, "SCP-939" },
            { RoleTypeId.Scp3114, "SCP-3114" },
            { RoleTypeId.Tutorial, "Tutorial" },
            { RoleTypeId.Flamingo, "Flamingo" },
            { RoleTypeId.AlphaFlamingo, "Alpha Flamingo"},
            { RoleTypeId.ZombieFlamingo, "Zombie Flamingo" },
            { default, "idk" },
        };
    }
}
