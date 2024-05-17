using System.Numerics;
using ImGuiNET;
using PlantsVsZombiesHacks.models;

namespace PlantsVsZombiesHacks.overlay_cheats;

public class PlantsEspOverlay(CheatClass cheatsClass)
{
    CheatClass cheatsClass = cheatsClass;

    private readonly Vector4 Red = new Vector4(1, 0, 0, 1); // red
    private readonly Vector4 Green = new Vector4(0, 1, 0, 1); // red
    private readonly Vector4 White = new Vector4(1, 1, 1, 1); // white

    readonly Vector2 LawnOffset = new Vector2(10, 70);
    readonly Vector2 PlantHeight = new Vector2(0, 80);

    public void RenderPlantsEspOverlay()
    {
        Rect pvzRect = OverlayCheatHelpers.GetPvzWindow();
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
}