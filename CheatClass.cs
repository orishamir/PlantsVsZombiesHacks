using PlantsVsZombiesHacks.toggle_cheats;
using Swed64;
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable ArrangeThisQualifier
// ReSharper disable ArrangeObjectCreationWhenTypeEvident

namespace PlantsVsZombiesHacks;

public class CheatClass
{
    readonly Swed swed = new Swed("popcapgame1");
    IntPtr moduleBase;

    public readonly SunsCheat Suns;
    public readonly FreePlantsToggleCheat FreePlantsToggleCheat;
    public readonly InstantRechargeToggleCheat InstantRechargeToggleCheat;
    public readonly InstantChopperRechargeToggleCheat InstantChopperRechargeToggleCheat;
    public readonly PlantGodmodeToggleCheat PlantGodmodeToggleCheat;
    public readonly PlantsCheat PlantsCheat;

    public CheatClass()
    {
        // Init memory
        moduleBase = swed.GetModuleBase(".exe");

        // Init cheats
        this.Suns = new SunsCheat(swed, moduleBase);
        this.FreePlantsToggleCheat = new FreePlantsToggleCheat(swed, moduleBase);
        this.InstantRechargeToggleCheat = new InstantRechargeToggleCheat(swed, moduleBase);
        this.InstantChopperRechargeToggleCheat = new InstantChopperRechargeToggleCheat(swed, moduleBase);
        this.PlantsCheat = new PlantsCheat(swed, moduleBase);
        this.PlantGodmodeToggleCheat = new PlantGodmodeToggleCheat(swed, moduleBase);
    }
}