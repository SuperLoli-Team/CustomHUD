using CustomHUD.API.Features.Interfaces.Classes;
using CustomHUD.Handlers;
using Exiled.API.Features;
using MEC;
using System;
using System.Xml.Linq;

using InterfaceAPI = CustomHUD.API.Features.Interfaces.API;

namespace CustomHUD
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CustomHUD";
        public override string Author => "Rozy";
        public static Plugin? Instance { get; private set; }
        public static Config? StaticConfig { get; private set; }
        public static CoroutineHandle InterfaceCoroutine { get; set; }
        public override Version Version => new(1, 0, 1);
        public override Version RequiredExiledVersion => new(9, 2, 1);
        public override void OnEnabled()
        {
            RueI.RueIMain.EnsureInit();

            InterfaceAPI.CachedElements.Clear();

            foreach (Type type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.BaseType != typeof(XElement))
                    continue;

                System.Reflection.ConstructorInfo? ctr = type.GetConstructor(Type.EmptyTypes);

                if (ctr == null)
                {
                    Log.Warn($"Interface | CachedElements | Skipped {type.FullName}. | Constructor for element not found.");
                    continue;
                }

                SLTElement? element = ctr.Invoke(null) as SLTElement;

                if (element == null)
                {
                    Log.Warn($"Interface | CachedElements | Skipped {type.FullName}. | Element failed to init.");
                    continue;
                }

                Log.Debug($"Interface | Added to cached [{element.Name}]");

                InterfaceAPI.CachedElements.Add(element);
            }

            if (InterfaceCoroutine == null || !InterfaceCoroutine.IsValid || !InterfaceCoroutine.IsRunning)
                InterfaceCoroutine = Timing.RunCoroutine(Coroutine.Refresh());

            Instance = this;
            StaticConfig = this.Config;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            InterfaceAPI.CachedElements.Clear();

            Timing.KillCoroutines(InterfaceCoroutine);

            Instance = null;
            StaticConfig = null;

            base.OnDisabled();
        }
    }
}