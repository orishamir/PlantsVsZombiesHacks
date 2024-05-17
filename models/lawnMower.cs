// ReSharper disable ArrangeThisQualifier
// ReSharper disable UnusedMember.Global

namespace PlantsVsZombiesHacks.models;

public struct LawnMower( // size: 72 bytes
    LawnmowerType lawnmowerType,
    float displayPosY,
    float displayPosX,
    Byte isDeleted
)
{
    public const int Size = 72;

    public LawnmowerType LawnmowerType = lawnmowerType; // +0x34
    public float DisplayPosY = displayPosY; // +0xC
    public float DisplayPosX = displayPosX; // +0x8
    public Byte IsDeleted = isDeleted; // +0x30
}

public enum LawnmowerType
{
    Normal = 0,
    PoolCleaner = 1,
    RoofCleaner = 2,
    Unidentifiable = 3,
}