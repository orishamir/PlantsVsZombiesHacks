// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

using Swed32;

namespace PlantsVsZombiesHacks.toggle_cheats;

public class InstantRechargeToggleCheat(Swed swed, IntPtr moduleBase) : IToggleCheat
{
    private const int InstantRechargeAddr = 0x958BC;

    public void Activate()
    {
        swed.WriteBytes(moduleBase, InstantRechargeAddr, [
            0x81, 0x47, 0x24, 0x0, 0x2, 0x0, 0x0, // add [edi+24], 000200
            0x90, // NOP
            0x90, // NOP
        ]);
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstantRechargeAddr, [
            0xff, 0x47, 0x24, // inc [edi + 24]
            0x8b, 0x47, 0x24, // mov eax, [edi+24]
            0x3b, 0x47, 0x28, // cmp eax, [edi+28]
        ]);
    }
}