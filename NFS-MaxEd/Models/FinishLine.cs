namespace NFSMaxEd.Models;

public class FinishLine : PointEntity
{
    private float _dimensionsX, _dimensionsY, _dimensionsZ;
    public FinishLine(EntityType entityType, string initialName = "") : base(entityType, initialName)
    {
    }
    public float DimensionsX { get => _dimensionsX;  set => Set(ref _dimensionsX, value); }
    public float DimensionsY { get => _dimensionsY; set => Set(ref _dimensionsY, value); }
    public float DimensionsZ { get => _dimensionsZ; set => Set(ref _dimensionsZ, value); }
}