// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable ArrangeThisQualifier
// ReSharper disable NotAccessedField.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global

using System.Numerics;

#pragma warning disable CS0414 // Field is assigned but its value is never used
#pragma warning disable CS0169 // Field is never used

namespace PlantsVsZombiesHacks.models;

public struct Plant // size: 332 bytes
(
    IntPtr baseAddress,
    UInt32 displayPosY,
    UInt32 displayPosX,
    UInt32 row,
    PlantType plantType,
    UInt32 column,
    UInt32 health,
    UInt32 maxHealth,
    Byte isDeleted,
    Byte isConsideredShoveling,
    UInt32 plantState)
{
    public const int Size = 332;
    public IntPtr BaseAddress = baseAddress;

    private UInt32 displayPosX = displayPosX; // +0x8
    private UInt32 displayPosY = displayPosY; // +0xC
    public UInt32 Row = row; // +0x1c
    public PlantType PlantType = plantType; // +0x24
    public UInt32 Column = column; // +0x28
    public UInt32 PlantState = plantState; // +0x3C
    public UInt32 Health = health; // +0x40
    public UInt32 MaxHealth = maxHealth; // +0x44
    public Byte IsDeleted = isDeleted; // +0x141
    public Byte IsConsideredShoveling = isConsideredShoveling; // +0x145

    public Vector2 DisplayPos = new Vector2(displayPosX, displayPosY);

    public override string ToString()
    {
        var columnString = $"({Column}, {Row})";
        var healthString = $"{Health}/{MaxHealth}";

        return string.Format($"{PlantType.ToString(),-10}  at  {columnString,-6}  |  {healthString,-10} HP");
    }
}