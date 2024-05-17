using Swed32;

namespace PlantsVsZombiesHacks.toggle_cheats;

public class PlantGodmodeToggleCheat(Swed swed, IntPtr moduleBase) : IToggleCheat
{
    private const int InstructionOffset = 0x1447a0; // "popcapgame1.exe" + 0x1447a0

    public void Activate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, [
            0x90, 0x90, 0x90, 0x90
        ]);
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, [
            0x83, 0x46, 0x40, 0xFC // add dword ptr [esi + 0x40], -04
        ]);
    }
}