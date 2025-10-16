namespace NFSMaxEd.Models;

public class ShortcutEntity : BaseEntity
{
    private float _maxChance = 1.0f;
    private float _minChance = 0.5f;
    private float _posX, _posY, _posZ;
    private float _rotation;
    public ShortcutEntity(string initialName = "") : base(initialName)
    {
        EntityType = EntityType.shortcut;
    }
    public float MaxChance { get => _maxChance; set => Set(ref _maxChance, value); }
    public float MinChance { get => _minChance; set => Set(ref _minChance, value); }
    public float PositionX { get => _posX; set => Set(ref _posX, value); }
    public float PositionY { get => _posY; set => Set(ref _posY, value); }
    public float PositionZ { get => _posZ; set => Set(ref _posZ, value); }
    public float Rotation { get => _rotation; set => Set(ref _rotation, value); }
}