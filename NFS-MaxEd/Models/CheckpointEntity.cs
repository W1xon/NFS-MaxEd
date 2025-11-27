namespace NFSMaxEd.Models;

public class CheckpointEntity : BaseEntity
{
    private int _timeBonus;
    private PointEntity _point;
    public CheckpointEntity(EntityType entityType, string initialName = "") : base(initialName)
    {
        EntityType = entityType;
        Point = new PointEntity();
    }
    public PointEntity Point
    {
        get => _point;
        set => Set(ref _point, value);
    }
    public int TimeBonus { get => _timeBonus; set => Set(ref _timeBonus, value); }
}