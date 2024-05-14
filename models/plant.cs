// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable ArrangeThisQualifier
// ReSharper disable NotAccessedField.Global

#pragma warning disable CS0414 // Field is assigned but its value is never used
#pragma warning disable CS0169 // Field is never used

namespace PlantsVsZombiesHacks.models;

public struct Plant // size: 332 bytes
{
    public UInt32 DisplayPosY; // +0x8
    public UInt32 DisplayPosX; // +0xC
    public UInt32 Row; // +0x1c
    public PlantType PlantType; // +0x24
    public UInt32 Column; // +0x28
    public UInt32 Health; // +0x40
    public UInt32 MaxHealth; // +0x44
    public Byte IsDeleted; // +0x141
    public Byte IsConsideredShoveling; // +0x145

    public Plant(
        UInt32 displayPosY,
        UInt32 displayPosX,
        UInt32 row,
        PlantType plantType,
        UInt32 column,
        UInt32 health,
        UInt32 maxHealth,
        Byte isDeleted,
        Byte isConsideredShoveling
    )
    {
        this.DisplayPosY = displayPosY;
        this.DisplayPosX = displayPosX;
        this.Row = row;
        this.PlantType = plantType;
        this.Column = column;
        this.Health = health;
        this.MaxHealth = maxHealth;
        this.IsDeleted = isDeleted;
        this.IsConsideredShoveling = isConsideredShoveling;
    }

    public override string ToString()
    {
        var columnString = $"({Column}, {Row})";
        var healthString = $"{Health}/{MaxHealth}";

        return string.Format($"{PlantType.ToString(),-10}  at  {columnString,-6}  |  {healthString,-10} HP");
    }
}