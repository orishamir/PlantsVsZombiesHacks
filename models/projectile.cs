// ReSharper disable ArrangeThisQualifier

using System.Numerics;

namespace PlantsVsZombiesHacks.models;

public struct Projectile( // size 216 bytes
    UInt32 isDeleted,
    ProjectileType projectileType,
    IntPtr baseAddress,
    UInt32 displayPosX,
    UInt32 displayPosY,
    float posX,
    float posY
)
{
    public static int Size = 148;

    public IntPtr BaseAddress = baseAddress;

    public UInt32 DisplayPosX = displayPosX; // +0x8
    public UInt32 DisplayPosY = displayPosY; // +0xC
    public float PosX = posX; // +0x30
    public float PosY = posY; // +0x4C
    public UInt32 IsDeleted = isDeleted; // +0x50
    public ProjectileType ProjectileType = projectileType; // +0x5C

    public Vector2 DisplayPos = new Vector2(displayPosX, displayPosY);
}

public enum ProjectileOffset
{
    DisplayPosX = 0x8,
    DisplayPosY = 0xC,
    PosX = 0x30,
    PosY = 0x4C,
    IsDeleted = 0x50,
    ProjectileType = 0x5C,
}

public enum ProjectileType
{
    Pea = 0,
    FrozenPea = 1,
    Cabbage = 2,
    Watermelon = 3,
    Puff = 4,
    WinterMelon = 5,
    FlamingPea = 6,
    Star = 7,
    Cacti = 8,
    Basketball = 9,
    Corn = 10,
    GiantCorn = 11,
    Butterstick = 12,
}