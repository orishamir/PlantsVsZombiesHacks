// ReSharper disable ArrangeThisQualifier
namespace PlantsVsZombiesHacks.models;

public struct LawnMower // size: 72 bytes
{
    public static int Size = 72;

    public LawnmowerType LawnmowerType; // +0x34
    public float DisplayPosY; // +0xC
    public float DisplayPosX; // +0x8
    public Byte IsDeleted; // +0x30

    public LawnMower(LawnmowerType lawnmowerType, float displayPosY, float displayPosX, Byte isDeleted)
    {
        this.LawnmowerType = lawnmowerType;
        this.DisplayPosY = displayPosY;
        this.DisplayPosX = displayPosX;
        this.IsDeleted = isDeleted;
    }
}

public enum LawnmowerType
{
    Normal = 0,
    PoolCleaner = 1,
    RoofCleaner = 2,
    Unidentifiable = 3,
}