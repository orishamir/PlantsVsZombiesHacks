using PlantsVsZombiesHacks.models;
using Swed32;

namespace PlantsVsZombiesHacks.entities;

public enum ProjectileOffset
{
    IsDeleted = 0x50,
    ProjectileType = 0x5C,
}

public class ProjectileCheat
{
    private IntPtr projectileStructPtr;
    private readonly Swed swed;

    public ProjectileCheat(Swed swed, IntPtr projectileStructPtr)
    {
        this.swed = swed;
        this.projectileStructPtr = projectileStructPtr;
    }

    public void Run()
    {
        Thread thread = new Thread(this.test);

        thread.Start();
    }

    public void test()
    {
        IntPtr arr = swed.ReadPointer(projectileStructPtr);

        while (true)
        {
            UInt32 projectilesTotal = swed.ReadUInt(projectileStructPtr, 0x10);
            Console.WriteLine("Projectiles Total: {0}", projectilesTotal);

            IntPtr ptr = arr;

            int projectilesCount = 0;
            while (projectilesCount != projectilesTotal)
            {
                Projectile projectile = ParseProjectile(ptr);
                if (projectile.IsDeleted == 1)
                {
                    ptr += Projectile.Size;
                    continue;
                }

                Console.WriteLine("Projectile: type={0}", projectile.ProjectileType);
                if (projectile.ProjectileType != ProjectileType.GiantCorn && (UInt32)projectile.ProjectileType != 6)
                {
                    swed.WriteUInt(projectile.BaseAddress, (int)ProjectileOffset.ProjectileType, (UInt32)ProjectileType.GiantCorn);
                }

                ptr += Projectile.Size;
                projectilesCount++;
            }

            Thread.Sleep(100);
        }
    }

    public Projectile ParseProjectile(IntPtr baseProjectileAddr)
    {
        UInt32 isDeleted = swed.ReadUInt(baseProjectileAddr, (int)ProjectileOffset.IsDeleted);
        ProjectileType projectileType =
            (ProjectileType)swed.ReadUInt(baseProjectileAddr, (int)ProjectileOffset.ProjectileType);

        return new Projectile(
            isDeleted: isDeleted,
            projectileType: projectileType,
            baseAddress: baseProjectileAddr
        );
    }
}