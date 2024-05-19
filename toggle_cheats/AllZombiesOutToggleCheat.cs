using Swed32;

namespace PlantsVsZombiesHacks.toggle_cheats;

public class AllZombiesOutToggleCheat(Swed swed, IntPtr moduleBase)
{
    private const int InstructionOffset = 0x17335;

    public void Activate()
    {
        Console.WriteLine("yes");
        swed.WriteBytes(moduleBase, InstructionOffset, [
            0xC7, 0x87, 0xB4, 0x55, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // mov [edi+55B4], 0
            0x90, 0x90,
        ]);
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, [
            0xFF, 0x8F, 0xB4, 0x55, 0x00, 0x00,
            0x8B, 0x8F, 0xB4, 0x55, 0x00, 0x00,
        ]);
    }
}