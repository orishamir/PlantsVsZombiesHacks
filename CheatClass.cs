using PlantsVsZombiesHacks.toggle_cheats;
using Swed64;
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers

namespace PlantsVsZombiesHacks;

public class CheatClass
{
    readonly Swed swed = new Swed("popcapgame1");
    IntPtr moduleBase;

    public readonly SunsCheat suns;
    public readonly FreePlantsToggleCheat FreePlantsToggleCheat;
    public readonly InstantRechargeToggleCheat InstantRechargeToggleCheat;

    public CheatClass()
    {
        InitMemory();

        // Init cheats
        this.suns = new SunsCheat(swed, moduleBase);
        this.FreePlantsToggleCheat = new FreePlantsToggleCheat(swed, moduleBase);
        this.InstantRechargeToggleCheat = new InstantRechargeToggleCheat(swed, moduleBase);
    }

    private void InitMemory()
    {
        moduleBase = swed.GetModuleBase(".exe");
    }
}