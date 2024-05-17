// ReSharper disable ArrangeThisQualifier

namespace PlantsVsZombiesHacks.models;

public struct Griditem // size: 236 bytes
{
    public UInt32 Column; // +0x10
    public UInt32 Row; // +0x14
    public GriditemType GriditemType; // +0x8
    public Byte IsDeleted; // +0x20
    public UInt32 IsSeeThrough; // +0x4c

    public Griditem(
        UInt32 column,
        UInt32 row,
        GriditemType griditemType,
        Byte isDeleted,
        UInt32 isSeeThrough
    )
    {
        this.Column = column;
        this.Row = row;
        this.GriditemType = griditemType;
        this.IsDeleted = isDeleted;
        this.IsSeeThrough = isSeeThrough;
    }

    public override string ToString()
    {
        var columnString = $"({Column}, {Row})";

        return string.Format($"{GriditemType.ToString(),-10}  at  {columnString,-6}");
    }
}

public enum GriditemType
{
    Grave = 1,
    DoomShroomCrater = 2,
    Vase = 7,
    Snail = 10,
}