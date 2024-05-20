// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeThisQualifier

using Swed32;

namespace PlantsVsZombiesHacks.entities;

public class EntitiesCheat
{
    public Swed swed;
    public IntPtr moduleBase;

    public IntPtr entitiesStructPtr;

    public ProjectileCheat ProjectileCheat;
    public PlantsCheat PlantsCheat;

    public EntitiesCheat(Swed swed, IntPtr moduleBase)
    {
        this.swed = swed;
        this.moduleBase = moduleBase;

        this.entitiesStructPtr = GetStructPtr();

        this.ProjectileCheat = new ProjectileCheat(swed, this.entitiesStructPtr + (int)EntityOffset.Projectiles);
        this.PlantsCheat = new PlantsCheat(swed, this.entitiesStructPtr + (int)EntityOffset.Plants);

        this.StartReloadingAddresses();
    }

    public void StartReloadingAddresses()
    {
        new Thread(() =>
        {
            IntPtr plantsStructPtr = GetStructPtr() + (int)EntityOffset.Plants;
            IntPtr projectilesStructPtr = GetStructPtr() + (int)EntityOffset.Projectiles;

            this.PlantsCheat.UpdateStructPtr(plantsStructPtr);
            this.ProjectileCheat.UpdateStructPtr(projectilesStructPtr);
            Thread.Sleep(10_000);
        }).Start();
    }

    public IntPtr GetStructPtr()
    {
        return swed.ReadPointer(moduleBase, [
                0x0032EC1C, 0x6c, 0x2c, 0x48c, 0x0, 0x3dc
            ]
        ) + 0xc4;
    }
}

public enum EntityOffset
{
    Plants = 0x0,
    Projectiles = 0x1c,
}