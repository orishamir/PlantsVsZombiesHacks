using System.Runtime.InteropServices;
using PlantsVsZombiesHacks.models;
using Swed32;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeThisQualifier

namespace PlantsVsZombiesHacks.entities;

public enum PlantOffset
{
    DisplayPosX = 0x8,
    DisplayPosY = 0xC,
    Row = 0x1C,
    PlantType = 0x24,
    Column = 0x28,
    PlantState = 0x3C,
    Health = 0x40,
    MaxHealth = 0x44,
    IsDeleted = 0x141,
    IsConsideredShoveling = 0x145,
}

public class PlantsCheat
{
    [DllImport("User32.dll")]
    public static extern bool GetAsyncKeyState(int ArrowKeys);

    private readonly Swed swed;
    private readonly IntPtr plantsStructPtr;

    public PlantsCheat(Swed swed, IntPtr plantsStructPtr)
    {
        this.swed = swed;
        this.plantsStructPtr = plantsStructPtr;
    }

    public List<Plant> ActivePlants = new List<Plant>();

    public void SetPlantHealth(Plant plant, UInt32 newHealth)
    {
        swed.WriteUInt(plant.BaseAddress, (int)PlantOffset.Health, newHealth);
    }

    public void ReloadPlantsList()
    {
        ActivePlants.Clear();
        UInt32 plantsCount = swed.ReadUInt(plantsStructPtr, 0x10);

        IntPtr ptr = swed.ReadPointer(plantsStructPtr);

        int plantsEncountered = 0;
        while (plantsEncountered != plantsCount)
        {
            Plant plant = parsePlant(ptr);
            if (plant.IsDeleted == 1)
            {
                ptr += Plant.Size;
                continue;
            }

            ActivePlants.Add(plant);

            ptr += Plant.Size;
            plantsEncountered++;
        }
    }

    public Plant parsePlant(IntPtr basePlantAddr)
    {
        PlantType plantType = (PlantType)swed.ReadUInt(basePlantAddr, (int)PlantOffset.PlantType);
        UInt32 health = swed.ReadUInt(basePlantAddr, (int)PlantOffset.Health);
        UInt32 plantState = swed.ReadUInt(basePlantAddr, (int)PlantOffset.PlantState);
        UInt32 maxHealth = swed.ReadUInt(basePlantAddr, (int)PlantOffset.MaxHealth);
        UInt32 displayPosX = swed.ReadUInt(basePlantAddr, (int)PlantOffset.DisplayPosX);
        UInt32 displayPosY = swed.ReadUInt(basePlantAddr, (int)PlantOffset.DisplayPosY);
        UInt32 column = swed.ReadUInt(basePlantAddr, (int)PlantOffset.Column);
        UInt32 row = swed.ReadUInt(basePlantAddr, (int)PlantOffset.Row);
        Byte isDeleted = swed.ReadBytes(basePlantAddr, (int)PlantOffset.IsDeleted, 1)[0];
        Byte isConsideredShoveling = swed.ReadBytes(basePlantAddr, (int)PlantOffset.IsConsideredShoveling, 1)[0];

        return new Plant(
            isDeleted: isDeleted,
            plantType: plantType,
            column: column,
            row: row,
            displayPosX: displayPosX,
            displayPosY: displayPosY,
            health: health,
            maxHealth: maxHealth,
            isConsideredShoveling: isConsideredShoveling,
            baseAddress: basePlantAddr,
            plantState: plantState
        );
    }
}