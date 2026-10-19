using Modding;
using UnityEngine;

namespace TheHuntIsOn.Modules;

internal class StartingItemsModule : Module
{
    #region Properties

    public override string MenuDescription => "Provides starting items to players on fresh saves.";

    #endregion

    #region Eventhandler

    private void ModHooks_GrantStartingItems()
    {
        if (IsModuleUsed)
        {
            var pd = PlayerData.instance;

            pd.maxHealth = 5;
            pd.maxHealthBase = 5;

            pd.lurienDefeated = true;
            pd.monomonDefeated = true;
            pd.hegemolDefeated = true;

            pd.charmSlots = 10;
            pd.gotCharm_36 = true;
            pd.gotCharm_2 = true;
            pd.royalCharmState = 3;
            pd.equippedCharm_36 = true;
            pd.equippedCharm_2 = true;
            

            pd.hasDreamNail = true;
            pd.dreamNailUpgraded = true;

            pd.hasLantern = true;
            pd.hasTramPass = true;
            pd.hasKingsBrand = true;

            pd.hasMap = true;
            //pd.mapAllRooms = true;
            pd.gladeDoorOpened = true;
            pd.troupeInTown = true;
            pd.geo = 10000;
        }
    }

    #endregion

    #region Methods

    internal override void Enable()
    {
        ModHooks.NewGameHook += ModHooks_GrantStartingItems;
    }

    internal override void Disable()
    {
        ModHooks.NewGameHook -= ModHooks_GrantStartingItems;
    }

    #endregion
}
