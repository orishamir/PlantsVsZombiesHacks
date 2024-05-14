// ReSharper disable BuiltInTypeReferenceStyle

// ReSharper disable NotAccessedField.Global
#pragma warning disable CS0414 // Field is assigned but its value is never used
#pragma warning disable CS0169 // Field is never used

namespace PlantsVsZombiesHacks.models;

public struct Plant // size: 0x14c (332d) 
{
    private IntPtr _a; // +0x0
    private IntPtr _b; // +0x4
    
    public UInt32 DisplayPosY; // +0x8
    public UInt32 DisplayPosX; // +0xC
    
    private UInt32 _c; // +0x10
    private UInt32 _d; // +0x14
    private UInt32 _e; // +0x18
    
    public UInt32 Row; // +0x1c
    
    private UInt32 _f; // 0x20
    
    public PlantType PlantType; // +0x24
    public UInt32 Column; // +0x28
    
    private UInt32 _h; // +0x2c
    private UInt32 _i; // +0x30
    private UInt32 _j; // +0x34
    private UInt32 _k; // +0x38
    private UInt32 _l; // +0x3c
    
    public UInt32 Health; // +0x40
    public UInt32 MaxHealth; // +0x44
    
    private UInt32[] _padding = new UInt32[65];

    public Plant()
    {
        _padding = new UInt32[65];
        _a = default;
        _b = default;
        DisplayPosY = 0;
        DisplayPosX = 0;
        _c = 0;
        _d = 0;
        _e = 0;
        Row = 0;
        _f = 0;
        PlantType = PlantType.Peashooter;
        Column = 0;
        _h = 0;
        _i = 0;
        _j = 0;
        _k = 0;
        _l = 0;
        Health = 0;
        MaxHealth = 0;
    }
}