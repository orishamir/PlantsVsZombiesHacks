// ReSharper disable ArrangeThisQualifier
// ReSharper disable UnusedMember.Global

namespace PlantsVsZombiesHacks.models;

public struct Griditem( // size: 236 bytes
    UInt32 column,
    UInt32 row,
    GriditemType griditemType,
    Byte isDeleted,
    UInt32 isSeeThrough
)
{
    public UInt32 Column = column; // +0x10
    public UInt32 Row = row; // +0x14
    public GriditemType GriditemType = griditemType; // +0x8
    public Byte IsDeleted = isDeleted; // +0x20
    public UInt32 IsSeeThrough = isSeeThrough; // +0x4c

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