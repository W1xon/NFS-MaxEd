using System.Text.RegularExpressions;

namespace NFSMaxEd.Models;

public class Moneybag : BaseEntity
{
    private EntityType _selectedType;
    private PointEntity _point;
    public Moneybag(EntityType moneybagType, string initialName = "") : base(initialName)
    {
        SelectedType = moneybagType;
        Point = new PointEntity();
    }

    public PointEntity Point
    {
        get => _point;
        set => Set(ref _point, value);
    }
    public EntityType SelectedType
    {
        get => _selectedType;
        set => Set(ref _selectedType, value);

    }
}