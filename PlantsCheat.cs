using System.Runtime.InteropServices;
using PlantsVsZombiesHacks.models;
using Swed64;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeThisQualifier

namespace PlantsVsZombiesHacks;

public enum PlantOffset
{
    DisplayPosY = 0x8,
    DisplayPosX = 0xC,
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

    IntPtr entitiesStructLoc = (IntPtr)0x1D79E054;
    private readonly Swed swed;
    private IntPtr moduleBase;

    public PlantsCheat(Swed swed, IntPtr moduleBase)
    {
        this.swed = swed;
        this.moduleBase = moduleBase;
    }

    private Thread reloadPlantsThread;
    private Thread listenHealthThread;

    public void Run()
    {
        // swed.WriteBytes(this.moduleBase, 0x69649, new[] { 0x89, 0x47, });
        // return;
        reloadPlantsThread = new Thread(this.ReloadPlantsList);
        listenHealthThread = new Thread(this.ListenHealth);

        reloadPlantsThread.Start();
        listenHealthThread.Start();
        activePlantsAccess = new Mutex(false);
    }

    public void Stop()
    {
        this.reloadPlantsThread.Abort();
        this.listenHealthThread.Abort();
    }

    private Plant[] activePlants = {};
    private Mutex activePlantsAccess;

    public void ListenHealth()
    {
        while (true)
        {
            lock (activePlantsAccess)
            {
                foreach (var plant in activePlants)
                {
                    if (plant.IsConsideredShoveling == 0)
                        continue;

                    while (GetAsyncKeyState(0x26)) // VK_UP
                    {
                        SetPlantHealth(plant, plant.Health + 200);
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                    }
                }
            }

            Thread.Sleep(TimeSpan.FromMilliseconds(1));
        }
    }

    public void SetPlantHealth(Plant plant, UInt32 newHealth)
    {
        swed.WriteUInt(plant.BaseAddress, (int)PlantOffset.Health, newHealth);
    }

    public void ReloadPlantsList()
    {
        IntPtr arr = HelperFuncs.FindDmaddy(entitiesStructLoc, new[] { 0x0 }, swed);

        while (true)
        {
            UInt32 plantsCount = swed.ReadUInt(entitiesStructLoc, 0x10);
            Console.WriteLine("Plants Count: {0}", plantsCount);

            lock (activePlantsAccess)
            {
                SetPlantsList(arr, plantsCount);
            }

            foreach (var plant in activePlants)
            {
                Console.WriteLine(plant);
            }

            Thread.Sleep(TimeSpan.FromMilliseconds(10));
        }
    }

    public void SetPlantsList(IntPtr startingPtr, UInt32 plantsCount)
    {
        activePlants = new Plant[plantsCount];

        int plantsEncountered = 0;
        while (plantsEncountered != plantsCount)
        {
            Plant plant = parsePlant(startingPtr);
            if (plant.IsDeleted == 1)
            {
                startingPtr += 332;
                continue;
            }

            activePlants[plantsEncountered] = plant;

            startingPtr += 332;
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