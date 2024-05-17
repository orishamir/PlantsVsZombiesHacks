using System.Diagnostics;
using System.Runtime.InteropServices;

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