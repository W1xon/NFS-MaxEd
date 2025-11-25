namespace NFSMaxEd.Models;

public class CharacterCashgrab : BaseEntity
{
    private List<Moneybag> _cannedPath = [];
    private PointEntity _spawn;
    private PointEntity _forceStartPosition;
    private int _skillLevel;

    public List<Moneybag> CannedPath
    {
        get => _cannedPath;
        set => Set(ref _cannedPath, value);
    }

    public PointEntity Spawn
    {
        get => _spawn;
        set => Set(ref _spawn, value);
    }

    public PointEntity ForceStartPosition
    {
        get => _forceStartPosition;
        set => Set(ref _forceStartPosition, value);
    }

    public int SkillLevel
    {
        get => _skillLevel;
        set => Set(ref _skillLevel, value);
    }
}