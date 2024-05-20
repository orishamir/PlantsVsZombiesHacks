// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeThisQualifier

using PlantsVsZombiesHacks.models;
using Swed32;

namespace PlantsVsZombiesHacks.entities;

public class ProjectileCheat(Swed swed, IntPtr projectileStructPtr)
{
    public Swed swed = swed;
    public IntPtr projectileStructPtr = projectileStructPtr;

    public List<Projectile> ActiveProjectiles = [];

    public void UpdateStructPtr(IntPtr newStructPtr)
    {
        this.projectileStructPtr = newStructPtr;
    }

    public void ReloadProjectilesList()
    {
        ActiveProjectiles.Clear();

        IntPtr ptr = swed.ReadPointer(projectileStructPtr);

        UInt32 projectilesCount = swed.ReadUInt(projectileStructPtr, 0x10);

        int projectilesEncountered = 0;
        while (projectilesEncountered != projectilesCount)
        {
            Projectile projectile = parseProjectile(ptr);
            if (projectile.IsDeleted == 1)
            {
                ptr += Projectile.Size;
                continue;
            }

            ActiveProjectiles.Add(projectile);

            ptr += Projectile.Size;
            projectilesEncountered++;
        }
    }

    public Projectile parseProjectile(IntPtr baseProjectileAddr)
    {
        UInt32 isDeleted = swed.ReadUInt(baseProjectileAddr, (int)ProjectileOffset.IsDeleted);
        ProjectileType projectileType =
            (ProjectileType)swed.ReadUInt(baseProjectileAddr, (int)ProjectileOffset.ProjectileType);
        UInt32 displayPosX = swed.ReadUInt(baseProjectileAddr, (int)ProjectileOffset.DisplayPosX);
        UInt32 displayPosY = swed.ReadUInt(baseProjectileAddr, (int)ProjectileOffset.DisplayPosY);
        float posX = swed.ReadFloat(baseProjectileAddr, (int)ProjectileOffset.PosX);
        float posY = swed.ReadFloat(baseProjectileAddr, (int)ProjectileOffset.PosY);

        return new Projectile(
            isDeleted: isDeleted,
            projectileType: projectileType,
            baseAddress: baseProjectileAddr,
            displayPosX: displayPosX,
            displayPosY: displayPosY,
            posX: posX,
            posY: posY
        );
    }
}