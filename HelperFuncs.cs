using Swed32;

namespace PlantsVsZombiesHacks;

public static class HelperFuncs
{
    public static IntPtr FindDmaddy(IntPtr addr, int[] offsets, Swed swed)
    {
        IntPtr tmp = addr;
        foreach (int offset in offsets)
        {
            tmp += offset;
            tmp = (IntPtr)BitConverter.ToInt32(swed.ReadBytes(tmp, 4));
        }

        return tmp;
    }
}