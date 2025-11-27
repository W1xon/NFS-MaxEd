namespace NFSMaxEd.Models;

public class TrafficSpawnTrigger : BaseEntity
{
    private float _radius;
    private string _trafficCharacter;
    private string _targetMarker;

    private PointEntity _point;
    public TrafficSpawnTrigger()
    {
        Point = new PointEntity();
    }
    public PointEntity Point
    {
        get => _point;
        set => Set(ref _point, value);
    }
    public float Radius { get => _radius; set => Set(ref _radius, value); }
    public string TargetMarker { get => _targetMarker; set => Set(ref _targetMarker, value); }
    public string TrafficCharacter { get => _trafficCharacter; set => Set(ref _trafficCharacter, value); }
}