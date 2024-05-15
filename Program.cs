using System.Numerics;
using ImGuiNET;
using ClickableTransparentOverlay;
using PlantsVsZombiesHacks.toggle_cheats;

// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable ArrangeThisQualifier
// ReSharper disable RedundantDefaultMemberInitializer
// ReSharper disable ArrangeObjectCreationWhenTypeEvident
namespace PlantsVsZombiesHacks;

public class Program : Overlay
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting up");

        Program program = new Program();
        program.Start().Wait();
    }

    readonly CheatClass cheatsClass = new CheatClass();
    int sunsCountValue = 500;

    bool freePlantsEnabled = false;
    bool instantRechargeEnabled = false;
    bool instantChopperRechargeEnabled = false;
    bool plantGodmodeEnabled = false;

    protected override void Render()
    {
        ImGui.Begin("PlantsVsZombies hacks");
        ImGui.SetWindowSize(new Vector2(520, 280));

        ImGui.SetWindowFontScale((float)1.8);
        if (ImGui.Checkbox("Free plants!", ref freePlantsEnabled))
        {
            freePlantsChanged();
        }

        if (ImGui.Checkbox("Instant Recharge!", ref instantRechargeEnabled))
        {
            instantRechargeChanged();
        }

        if (ImGui.Checkbox("Instant Chopper Recharge!", ref instantChopperRechargeEnabled))
        {
            instantChopperRechargeChanged();
        }

        if (ImGui.Checkbox("Plant Godmode!", ref plantGodmodeEnabled))
        {
            plantGodmodeChanged();
        }

        ImGui.InputInt("Suns Count", ref sunsCountValue, 50, 100);
        if (ImGui.Button("Set"))
        {
            this.cheatsClass.Suns.SetSuns(sunsCountValue);
        }

        if (ImGui.Button("temp"))
        {
            cheatsClass.PlantsCheat.Run();
        }

        ImGui.End();
    }

    private void freePlantsChanged()
    {
        if (freePlantsEnabled)
            this.cheatsClass.FreePlantsToggleCheat.Activate();
        else
            this.cheatsClass.FreePlantsToggleCheat.Deactivate();
    }

    private void instantRechargeChanged()
    {
        if (instantRechargeEnabled)
            this.cheatsClass.InstantRechargeToggleCheat.Activate();
        else
            this.cheatsClass.InstantRechargeToggleCheat.Deactivate();
    }

    private void instantChopperRechargeChanged()
    {
        if (instantChopperRechargeEnabled)
            this.cheatsClass.InstantChopperRechargeToggleCheat.Activate();
        else
            this.cheatsClass.InstantChopperRechargeToggleCheat.Deactivate();
    }

    private void plantGodmodeChanged()
    {
        if (plantGodmodeEnabled)
            this.cheatsClass.PlantGodmodeToggleCheat.Activate();
        else
            this.cheatsClass.PlantGodmodeToggleCheat.Deactivate();
    }
}