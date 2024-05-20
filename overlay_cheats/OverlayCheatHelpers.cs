using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using ImGuiNET;

namespace PlantsVsZombiesHacks.overlay_cheats;

public static class OverlayCheatHelpers
{
    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

    public static Rect GetPvzWindow()
    {
        Process[] processes = Process.GetProcessesByName("popcapgame1");
        IntPtr ptr = processes[0].MainWindowHandle;
        Rect pvzRect = new Rect();
        GetWindowRect(ptr, ref pvzRect);

        return pvzRect;
    }
}

public struct Rect
{
    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }
}

public static class Color
{
    public static readonly uint Red = ImGui.ColorConvertFloat4ToU32(new Vector4(1, 0, 0, 1));
    public static readonly uint Green = ImGui.ColorConvertFloat4ToU32(new Vector4(0, 1, 0, 1));
    public static readonly uint White = ImGui.ColorConvertFloat4ToU32(new Vector4(1, 1, 1, 1));
}