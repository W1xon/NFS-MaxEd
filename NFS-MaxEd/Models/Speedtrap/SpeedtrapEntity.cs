namespace NFSMaxEd.Models;

public class SpeedtrapEntity : BaseEntity
{
    private PointEntity _point;

    public SpeedtrapEntity()
    {
        Point = new PointEntity();
    }
    public PointEntity Point
    {
        get => _point;
        set => Set(ref _point, value);
    }
    private int _reputation;
    
}