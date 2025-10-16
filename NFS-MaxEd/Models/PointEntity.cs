namespace NFSMaxEd.Models;

public class PointEntity : BaseEntity
{
    private float _positionX, _positionY, _positionZ;
    private float _rotation;
    public PointEntity(EntityType entityType, string initialName = "") : base(initialName)
    {
        EntityType = entityType;
    }
    public float PositionX { get => _positionX; set => Set(ref _positionX, value); }
    public float PositionY { get => _positionY; set => Set(ref _positionY, value); }
    public float PositionZ { get => _positionZ; set => Set(ref _positionZ, value); }
    public float Rotation { get => _rotation; set => Set(ref _rotation, value); }
}