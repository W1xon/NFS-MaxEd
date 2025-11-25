namespace NFSMaxEd.Models;

public class SpeedtrapEntity : BaseEntity
{
    
    private float _positionX, _positionY, _positionZ;
    private int _reputation;
    public float PositionX { get => _positionX; set => Set(ref _positionX, value); }
    public float PositionY { get => _positionY; set => Set(ref _positionY, value); }
    public float PositionZ { get => _positionZ; set => Set(ref _positionZ, value); }
    
}