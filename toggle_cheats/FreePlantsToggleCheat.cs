// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

using Swed32;

namespace PlantsVsZombiesHacks.toggle_cheats;

public class FreePlantsToggleCheat(Swed swed, IntPtr moduleBase) : IToggleCheat
{
    private const int InstructionOffset = 0x1F634;

    public void Activate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, [
            0x90, 0x90
        ]);
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, [
            0x29, 0xde // sub esi, ebx
        ]);
    }
}