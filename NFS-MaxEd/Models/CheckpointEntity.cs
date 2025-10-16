namespace NFSMaxEd.Models;

public class CheckpointEntity : BaseEntity
{
    private float _positionX, _positionY, _positionZ;
    private float _rotation;
    private int _timeBonus;

    public CheckpointEntity(EntityType entityType, string initialName = "") : base(initialName)
    {
        EntityType = entityType;
    }
    public float PositionX { get => _positionX; set => Set(ref _positionX, value); }
    public float PositionY { get => _positionY; set => Set(ref _positionY, value); }
    public float PositionZ { get => _positionZ; set => Set(ref _positionZ, value); }
    public float Rotation { get => _rotation; set => Set(ref _rotation, value); }
    public int TimeBonus { get => _timeBonus; set => Set(ref _timeBonus, value); }
}