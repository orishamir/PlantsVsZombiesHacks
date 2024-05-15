// ReSharper disable ArrangeThisQualifier

namespace PlantsVsZombiesHacks.models;

public struct Projectile // size 216 bytes
{
    public UInt32 IsDead; // +0x50
    public ProjectileType ProjectileType; // +0x5C

    public Projectile(UInt32 isDead, ProjectileType projectileType)
    {
        this.IsDead = isDead;
        this.ProjectileType = projectileType;
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