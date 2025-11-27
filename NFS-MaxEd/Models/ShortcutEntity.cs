namespace NFSMaxEd.Models;

public class ShortcutEntity : BaseEntity
{
    private float _maxChance = 1.0f;
    private float _minChance = 0.5f;
    private PointEntity _point;
    public ShortcutEntity(string initialName = "") : base(initialName)
    {
        EntityType = EntityType.shortcut;
        Point = new PointEntity();
    }
    public PointEntity Point
    {
        get => _point;
        set => Set(ref _point, value);
    }
    public float MaxChance { get => _maxChance; set => Set(ref _maxChance, value); }
    public float MinChance { get => _minChance; set => Set(ref _minChance, value); }
}