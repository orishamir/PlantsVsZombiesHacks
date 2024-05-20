using System.Numerics;
using ImGuiNET;
using PlantsVsZombiesHacks.models;

namespace PlantsVsZombiesHacks.overlay_cheats;

public class ProjectilesEspOverlay(CheatClass cheatsClass)
{
    CheatClass cheatsClass = cheatsClass;

    private readonly Vector2 projectileSquareSize = new Vector2(20, 20);
    private readonly Vector2 projectileOffset = new Vector2(18, 40);

    public void RenderProjectilesEspOverlay()
    {
        Rect pvzRect = OverlayCheatHelpers.GetPvzWindow();
        float windowWidth = pvzRect.Right - pvzRect.Left;
        float windowHeight = pvzRect.Bottom - pvzRect.Top;

        ImGui.SetNextWindowPos(new Vector2(pvzRect.Left, pvzRect.Top));
        ImGui.SetNextWindowSize(new Vector2(windowWidth, windowHeight));

        // Start ImGui window
        ImGui.Begin("Projectiles ESP overlay",
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
        cheatsClass.EntitiesCheat.ProjectileCheat.ReloadProjectilesList();
        foreach (Projectile projectile in cheatsClass.EntitiesCheat.ProjectileCheat.ActiveProjectiles)
        {
            Vector2 projectileStartPos = ImGui.GetWindowPos() + projectile.DisplayPos + projectileOffset;

            drawList.AddRect(
                 projectileStartPos - projectileSquareSize,
                 projectileStartPos + projectileSquareSize,
                Color.White,
                0.3f,
                ImDrawFlags.RoundCornersAll,
                3.0f
            );
        }

        ImGui.End();
    }
}