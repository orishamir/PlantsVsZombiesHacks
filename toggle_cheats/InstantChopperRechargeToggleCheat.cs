using Swed32;

namespace PlantsVsZombiesHacks.toggle_cheats;

public enum ChomperState
{
    WaitingForPrey = 1, // Pretty much "idle"
    Targeting = 10,
    KilledZombie = 11, // Not so sure about this
    Digesting = 13,  // The one that takes most time
    FinishedEating = 14, // Im not sure the difference between this and 1.
}

public class InstantChopperRechargeToggleCheat(Swed swed, IntPtr moduleBase) : IToggleCheat
{
    /*
     This cheat works like this:
     All plants have a "state" variable at offset `PlantOffset.PlantState`, but only some plants use it.
     In the Chomper's case, its state can have several things as in ChomperState enum.

     For this cheat, we modify two instructions:
     First one is responsible for setting the Chomper's state to "Eating"
     Second one is responsible for setting the Chomper's state to "Digesting"

     We can get away with just modifying the second one, but for minimal cooldown between attacks we modify both.
     */
    private const int InstructionOffset1 = 0x678E7; // "popcapgame1.exe" + 0x678E7
    private const int InstructionOffset2 = 0x6789E; // "popcapgame1.exe" + 0x6789E

    public void Activate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset1, [
            0xC7, 0x47, 0x3C, (byte)ChomperState.FinishedEating, 0x00, 0x00, 0x00 // mov [edi + 3C], 0xE
        ]);

        swed.WriteBytes(moduleBase, InstructionOffset2, [
            0xC7, 0x47, 0x3C, (byte)ChomperState.FinishedEating, 0x00, 0x00, 0x00 // mov [edi + 3C], 0xE
        ]);
    }

    public void Deactivate()
    {
        swed.WriteBytes(moduleBase, InstructionOffset1, [
            0xC7, 0x47, 0x3C, (byte)ChomperState.Digesting, 0x00, 0x00, 0x00 // mov [edi + 3C], 0xD
        ]);

        swed.WriteBytes(moduleBase, InstructionOffset2, [
            0xC7, 0x47, 0x3C, (byte)ChomperState.KilledZombie, 0x00, 0x00, 0x00 // mov [edi + 3C], 0xB
        ]);
    }
}