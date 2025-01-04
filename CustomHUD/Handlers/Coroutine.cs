using Exiled.API.Features;
using RueI.Displays;
using System;
using System.Collections.Generic;
using InterfaceAPI = CustomHUD.API.Features.Interfaces.API;
using CustomHUD.API.Features.Interfaces.Classes;
using System.Linq;

namespace CustomHUD.Handlers
{
    public static class Coroutine
    {
        public static IEnumerator<float> Refresh()
        {
            while (true)
            {
                foreach (var pl in Player.List)
                {
                    try
                    {
                        if (pl == null || !pl.IsConnected || !pl.IsAlive) continue;

                        if (!InterfaceAPI.DisplayList.Any(x => x.ReferenceHub == pl.ReferenceHub)) InterfaceAPI.DisplayList.Add(new(pl.ReferenceHub));

                        Display playerDisplay = InterfaceAPI.DisplayList.Find(x => x.ReferenceHub == pl.ReferenceHub);

                        if (playerDisplay == null) continue;

                        if (!InterfaceAPI.CachedPlayerElements.ContainsKey(pl))
                            InterfaceAPI.CachedPlayerElements.Add(pl, InterfaceAPI.CachedElements);

                        if (InterfaceAPI.CachedPlayerElements.TryGetValue(pl, out var savedElements))
                        {
                            playerDisplay.Elements.Clear();

                            foreach (SLTElement element in savedElements)
                            {
                                playerDisplay.Elements.Add(element);
                            }
                        }

                        pl.ShowHint(ElemCombiner.Combine(playerDisplay.Coordinator, playerDisplay.Elements), 1);
                    }
                    catch (System.Exception ex)
                    {
                        Log.Error(ex);
                    }
                }

                yield return MEC.Timing.WaitForSeconds(0.6f);
            }
        }
    }
}
