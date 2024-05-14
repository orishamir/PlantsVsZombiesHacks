using Swed64;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

namespace PlantsVsZombiesHacks.cheats;

public class InstantRechargeCheat : ICheat
{
    private const int InstantRechargeAddr = 0x958BC;

    private readonly Swed swed;
    private IntPtr moduleBase;

    public InstantRechargeCheat(Swed swed, IntPtr moduleBase)
    {
        this.swed = swed;
        this.moduleBase = moduleBase;
    }

    public void Activate()
    {
        swed.WriteBytes(moduleBase, InstantRechargeAddr, new byte[]
        {
            0x81, 0x47, 0x24, 0x0, 0x2, 0x0, 0x0, // add [edi+24], 000200
            0x90, // NOP
            0x90, // NOP
        });
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstantRechargeAddr, new byte[]
        {
            0xff, 0x47, 0x24, // inc [edi + 24]
            0x8b, 0x47, 0x24, // mov eax, [edi+24]
            0x3b, 0x47, 0x28, // cmp eax, [edi+28]
        });
    }
}
