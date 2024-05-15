// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeThisQualifier

using Swed64;

namespace PlantsVsZombiesHacks.entities;

public class EntitiesCheat
{
    public IntPtr entitiesStructLoc;

    private readonly Swed swed;
    private IntPtr moduleBase;

    public ProjectileCheat ProjectileCheat;
    public PlantsCheat PlantsCheat;

    public EntitiesCheat(Swed swed, IntPtr moduleBase)
    {
        this.swed = swed;
        this.moduleBase = moduleBase;

        entitiesStructLoc = HelperFuncs.FindDmaddy(moduleBase, new[]
            {
                0x0032EC1C, 0x6c, 0x2c, 0x48c, 0x0, 0x3dc,
            },
            swed
        ) + 0xc4;
        Console.WriteLine("{0:x}", entitiesStructLoc);
        this.ProjectileCheat = new ProjectileCheat(swed, entitiesStructLoc + (int)EntityOffset.Projectiles);
        this.PlantsCheat = new PlantsCheat(swed, entitiesStructLoc + (int)EntityOffset.Plants);
    }
}

public enum EntityOffset
{
    Plants = 0x0,
    Projectiles = 0x1c,
}
