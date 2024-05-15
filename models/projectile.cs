// ReSharper disable ArrangeThisQualifier

namespace PlantsVsZombiesHacks.models;

public struct Projectile // size 216 bytes
{
    public static int Size = 148;

    public IntPtr BaseAddress;

    public UInt32 IsDeleted; // +0x50
    public ProjectileType ProjectileType; // +0x5C

    public Projectile(UInt32 isDeleted, ProjectileType projectileType, IntPtr baseAddress)
    {
        this.IsDeleted = isDeleted;
        this.ProjectileType = projectileType;
        this.BaseAddress = baseAddress;
    }
}

public enum ProjectileType
{
    Pea = 0,
    FrozenPea = 1,
    Cabbage = 2,
    Watermelon = 3,

    WinterMelon = 5,

    Star = 7,
    Cacti = 8,
    Basketball = 9,
    Corn = 10,
    GiantCorn = 11,
    Butterstick = 12,
}