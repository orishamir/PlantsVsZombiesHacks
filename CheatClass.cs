using PlantsVsZombiesHacks.cheats;
using Swed64;
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers

namespace PlantsVsZombiesHacks;

public class CheatClass
{
    readonly Swed swed = new Swed("popcapgame1");
    IntPtr moduleBase;

    public readonly SunsCheat suns;
    public readonly FreePlantsCheat freePlantsCheat;
    public readonly InstantRechargeCheat instantRechargeCheat;

    public CheatClass()
    {
        InitMemory();

        // Init cheats
        this.suns = new SunsCheat(swed, moduleBase);
        this.freePlantsCheat = new FreePlantsCheat(swed, moduleBase);
        this.instantRechargeCheat = new InstantRechargeCheat(swed, moduleBase);
    }

    private void InitMemory()
    {
        moduleBase = swed.GetModuleBase(".exe");
    }

}