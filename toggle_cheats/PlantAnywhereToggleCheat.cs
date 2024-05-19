using Swed32;

namespace PlantsVsZombiesHacks.toggle_cheats;

public class PlantAnywhereToggleCheat(Swed swed, IntPtr moduleBase)
{
    private const int InstructionOffset = 0x1334D;

    public void Activate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, [
            0x31, 0xC0 // xor eax, eax
        ]);
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, [
            0x85, 0xC0 // test eax, eax
        ]);
    }

}