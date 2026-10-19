using KorzUtils.Enums;
using KorzUtils.Helper;
using Modding;

namespace TheHuntIsOn.Modules;

internal class CharmNerfModule : Module
{
    #region Properties

    public override string MenuDescription => "Adjusts charm notch costs of certain charms.";

    #endregion

    #region Eventhandler

    private bool ModHooks_SetPlayerBoolHook(string name, bool orig)
    {
        if (IsModuleUsed && name.StartsWith("gotCharm_") && orig)
        {
            if (int.TryParse(name.Substring("gotCharm_".Length), out int charmNumber))
                CoroutineHelper.WaitFrames(x =>
                {
                    switch (charmNumber)
                    {
                        case 01: // Gathering Swarm
                            CharmHelper.SetCharmCost(x, 1);
                            break;
                        case 02: // Wayward Compass
                            CharmHelper.SetCharmCost(x, 1);
                            break;
                        case 03: // Grubsong
                            CharmHelper.SetCharmCost(x, 2);
                            break;
                        case 04: // Stalwart Shell
                            CharmHelper.SetCharmCost(x, 2);
                            break;
                        case 05: // Baldur Shell
                            CharmHelper.SetCharmCost(x, 3);
                            break;
							
                        case 06: // Fury
                            CharmHelper.SetCharmCost(x, 1);
                            break;
                        case 07: // Quick Focus
                            CharmHelper.SetCharmCost(x, 3);
                            break;
                        case 08: // Lifeblood Heart
                            CharmHelper.SetCharmCost(x, 1);
                            break;
                        case 09: // Lifeblood Core
                            CharmHelper.SetCharmCost(x, 2);
                            break;
                        case 10: // Defender's Crest
                            CharmHelper.SetCharmCost(x, 2);
                            break;
                        case 11: // Flukenest
                            CharmHelper.SetCharmCost(x, 2);
                            break;
                        case 12: // Thorns of Agony
                            CharmHelper.SetCharmCost(x, 2);
                            break;
                        case 13: // Mark of Pride
                            CharmHelper.SetCharmCost(x, 4);
                            break;
							
                        case 17: // Spore Shroom
                            CharmHelper.SetCharmCost(x, 3);
                            break;
                        case 23: // Heart
                            CharmHelper.SetCharmCost(x, 3);
                            break;
                        case 26: // Nailmaster's Glory
                            CharmHelper.SetCharmCost(x, 2);
                            break;
                        default:
                            break;
                    }
                }, (CharmRef)charmNumber, true, 3);
        }
        return orig;
    }

    #endregion

    #region Methods

    internal override void Enable() => ModHooks.SetPlayerBoolHook += ModHooks_SetPlayerBoolHook;

    internal override void Disable() => ModHooks.SetPlayerBoolHook -= ModHooks_SetPlayerBoolHook;
	#endregion
}
