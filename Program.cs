// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable ArrangeThisQualifier
// ReSharper disable RedundantDefaultMemberInitializer
// ReSharper disable ArrangeObjectCreationWhenTypeEvident

using ImGuiNET;
using ClickableTransparentOverlay;
using PlantsVsZombiesHacks.overlay_cheats;

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
    bool plantInfiniteHealthEnabled = false;
    bool plantsEspEnabled = false;

    private readonly PlantsEspOverlay plantsEspOverlay;

    public Program()
    {
        plantsEspOverlay = new PlantsEspOverlay(cheatsClass);
    }

    protected override void Render()
    {
        ReplaceFont(@"C:\Windows\Fonts\calibri.ttf", 30, FontGlyphRangeType.English);

        ImGui.Begin("PlantsVsZombies hacks", ImGuiWindowFlags.AlwaysAutoResize);

        if (ImGui.TreeNode("Toggleables"))
        {
            ImGui.Indent();

            RenderToggleables();
            ImGui.Unindent();
            ImGui.TreePop();
        }

        ImGui.Separator();

        ImGui.InputInt("Suns Count", ref sunsCountValue, 50, 100);
        if (ImGui.Button("Set"))
            this.cheatsClass.Suns.SetSuns(sunsCountValue);

        ImGui.Checkbox("Plants ESP", ref plantsEspEnabled);
        if (plantsEspEnabled)
            plantsEspOverlay.RenderPlantsEspOverlay();

        ImGui.Text("");
        ImGui.End();
    }

    public void RenderToggleables()
    {
        if (ImGui.Checkbox("Free plants!", ref freePlantsEnabled))
            freePlantsChanged();

        if (ImGui.Checkbox("Instant Recharge!", ref instantRechargeEnabled))
            instantRechargeChanged();

        if (ImGui.Checkbox("Instant Chopper Recharge!", ref instantChopperRechargeEnabled))
            instantChopperRechargeChanged();

        if (ImGui.Checkbox("Plant Infinite Health!", ref plantInfiniteHealthEnabled))
            plantGodmodeChanged();
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
        if (plantInfiniteHealthEnabled)
            this.cheatsClass.PlantGodmodeToggleCheat.Activate();
        else
            this.cheatsClass.PlantGodmodeToggleCheat.Deactivate();
    }
}