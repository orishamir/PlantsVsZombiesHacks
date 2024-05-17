// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

using Swed32;

namespace PlantsVsZombiesHacks;

public class SunsCheat(Swed swed, IntPtr moduleBase)
{
    public void SetSuns(int count)
    {
        swed.WriteInt(findSunsCountPtr(), 0x5578, count);
    }

    public UInt32 GetSuns()
    {
        return swed.ReadUInt(findSunsCountPtr(), 0x5578);
    }

    private IntPtr findSunsCountPtr()
    {
        return swed.ReadPointer(moduleBase, [0x331c50, 0x48c, 0x0, 0x3dc]);
    }
}