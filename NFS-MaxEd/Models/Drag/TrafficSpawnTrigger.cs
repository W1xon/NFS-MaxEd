namespace NFSMaxEd.Models;

public class TrafficSpawnTrigger : BaseEntity
{
    private float _positionX, _positionY, _positionZ;
    private float _rotation;
    private float _radius;
    private string _trafficCharacter;
    private string _targetMarker;

    public float PositionX { get => _positionX; set => Set(ref _positionX, value); }
    public float PositionY { get => _positionY; set => Set(ref _positionY, value); }
    public float PositionZ { get => _positionZ; set => Set(ref _positionZ, value); }
    public float Rotation { get => _rotation; set => Set(ref _rotation, value); }
    public float Radius { get => _radius; set => Set(ref _radius, value); }
    public string TargetMarker { get => _targetMarker; set => Set(ref _targetMarker, value); }
    public string TrafficCharacter { get => _trafficCharacter; set => Set(ref _trafficCharacter, value); }
}