using Swed32;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

namespace PlantsVsZombiesHacks.toggle_cheats;

public class FreePlantsToggleCheat: IToggleCheat
{
    private const int InstructionOffset = 0x1F634;

    private readonly Swed swed;
    private IntPtr moduleBase;

    public FreePlantsToggleCheat(Swed swed, IntPtr moduleBase)
    {
        this.swed = swed;
        this.moduleBase = moduleBase;
    }

    public void Activate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, new byte[]
        {
            0x90, 0x90
        });
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, new byte[]
        {
            0x29, 0xde // sub esi, ebx
        });
    }
}