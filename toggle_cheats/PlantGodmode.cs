using Swed64;

namespace PlantsVsZombiesHacks.toggle_cheats;

public class PlantGodmodeToggleCheat : IToggleCheat
{
    private const int InstructionOffset = 0x1447a0; // "popcapgame1.exe" + 0x1447a0


    private readonly Swed swed;
    private IntPtr moduleBase;

    public PlantGodmodeToggleCheat(Swed swed, IntPtr moduleBase)
    {
        this.swed = swed;
        this.moduleBase = moduleBase;
    }

    public void Activate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, new byte[]
        {
            0x90, 0x90, 0x90, 0x90,
        });
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset, new byte[]
        {
            0x83, 0x46, 0x40, 0xFC, // add dword ptr [esi + 0x40], -04
        });
    }
}