// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeThisQualifier

using Swed32;

namespace PlantsVsZombiesHacks.entities;

public class EntitiesCheat
{
    public IntPtr entitiesStructPtr;

    public ProjectileCheat ProjectileCheat;
    public PlantsCheat PlantsCheat;

    public EntitiesCheat(Swed swed, IntPtr moduleBase)
    {
        entitiesStructPtr = swed.ReadPointer(moduleBase, new[]
            {
                0x0032EC1C, 0x6c, 0x2c, 0x48c, 0x0, 0x3dc,
            }
        ) + 0xc4;

        this.ProjectileCheat = new ProjectileCheat(swed, entitiesStructPtr + (int)EntityOffset.Projectiles);
        this.PlantsCheat = new PlantsCheat(swed, entitiesStructPtr + (int)EntityOffset.Plants);
    }
}

public enum EntityOffset
{
    Plants = 0x0,
    Projectiles = 0x1c,
}