using Swed32;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
namespace PlantsVsZombiesHacks;

public class SunsCheat
{
    private readonly Swed swed;
    private IntPtr moduleBase;

    public SunsCheat(Swed swed, IntPtr moduleBase)
    {
        this.swed = swed;
        this.moduleBase = moduleBase;
    }

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
        return swed.ReadPointer(moduleBase, new[] { 0x331c50, 0x48c, 0x0, 0x3dc });;
    }
}