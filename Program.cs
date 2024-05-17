// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable ArrangeThisQualifier
// ReSharper disable RedundantDefaultMemberInitializer
// ReSharper disable ArrangeObjectCreationWhenTypeEvident

using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using ImGuiNET;
using ClickableTransparentOverlay;
using PlantsVsZombiesHacks.models;

namespace PlantsVsZombiesHacks;

public class Program : Overlay
{
    private readonly Vector4 Red = new Vector4(1, 0, 0, 1); // red
    private readonly Vector4 Green = new Vector4(0, 1, 0, 1); // red
    private readonly Vector4 White = new Vector4(1, 1, 1, 1); // white

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

    public struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Starting up");

        Program program = new Program();
        program.Start().Wait();
    }

    readonly CheatClass cheatsClass = new CheatClass();

    readonly Vector2 LawnOffset = new Vector2(10, 70);
    readonly Vector2 PlantHeight = new Vector2(0, 80);

    int sunsCountValue = 500;

    bool freePlantsEnabled = false;
    bool instantRechargeEnabled = false;
    bool instantChopperRechargeEnabled = false;
    bool plantInfiniteHealthEnabled = false;
    bool plantsEspEnabled = false;

    protected override void Render()
    {
        ImGui.Begin("PlantsVsZombies hacks",
            ImGuiWindowFlags.AlwaysAutoResize
        );
        ImGui.SetWindowFontScale((float)1.8);

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
            RenderPlantsEspOverlay();

        ImGui.Text("");
        ImGui.End();
    }

    public void RenderPlantsEspOverlay()
    {
        Rect pvzRect = GetPvzWindow();
        float windowWidth = pvzRect.Right - pvzRect.Left;
        float windowHeight = pvzRect.Bottom - pvzRect.Top;

        ImGui.SetNextWindowPos(new Vector2(pvzRect.Left, pvzRect.Top));
        ImGui.SetNextWindowSize(new Vector2(windowWidth, windowHeight));

        // Start ImGui window
        ImGui.Begin("ESP overlay",
            ImGuiWindowFlags.NoDecoration
            | ImGuiWindowFlags.NoBackground
            | ImGuiWindowFlags.NoBringToFrontOnFocus
            | ImGuiWindowFlags.NoMove
            | ImGuiWindowFlags.NoInputs
            | ImGuiWindowFlags.NoCollapse
            | ImGuiWindowFlags.NoScrollbar
            | ImGuiWindowFlags.NoScrollWithMouse
        );
        ImDrawListPtr drawList = ImGui.GetWindowDrawList();

        // drawList.AddRect(
        //     ImGui.GetWindowPos() + new Vector2(4, 1),
        //     ImGui.GetWindowPos() + ImGui.GetWindowSize() - new Vector2(4, 1),
        //     ImGui.ColorConvertFloat4ToU32(Red)
        // );

        cheatsClass.EntitiesCheat.PlantsCheat.ReloadPlantsList();
        foreach (Plant plant in cheatsClass.EntitiesCheat.PlantsCheat.ActivePlants)
        {
            Vector2 GreenHeight = PlantHeight * plant.Health / plant.MaxHealth;

            Vector2 plantStartPos = ImGui.GetWindowPos()
                + LawnOffset
                + plant.DisplayPos - PlantHeight / 2;

            Vector2 RedHeight = PlantHeight - GreenHeight;

            drawList.AddLine(
                plantStartPos,
                plantStartPos + RedHeight,
                ImGui.ColorConvertFloat4ToU32(Red),
                3.0f
            );

            drawList.AddLine(
                plantStartPos + RedHeight,
                plantStartPos + RedHeight + GreenHeight,
                ImGui.ColorConvertFloat4ToU32(Green),
                3.0f
            );
        }

        ImGui.End();
    }

    public Rect GetPvzWindow()
    {
        Process[] processes = Process.GetProcessesByName("popcapgame1");
        IntPtr ptr = processes[0].MainWindowHandle;
        Rect pvzRect = new Rect();
        GetWindowRect(ptr, ref pvzRect);

        return pvzRect;
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