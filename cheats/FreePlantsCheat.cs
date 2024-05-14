using Swed64;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

namespace PlantsVsZombiesHacks.cheats;

public class FreePlantsCheat: ICheat
{
    private const int FreePlantsAddr = 0x1F634;

    private readonly Swed swed;
    private IntPtr moduleBase;

    public FreePlantsCheat(Swed swed, IntPtr moduleBase)
    {
        this.swed = swed;
        this.moduleBase = moduleBase;
    }

    public void Activate()
    {
        swed.WriteBytes(moduleBase, FreePlantsAddr, new byte[]
        {
            0x90, 0x90
        });
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, FreePlantsAddr, new byte[]
        {
            0x29, 0xde // sub esi, ebx
        });
    }
}