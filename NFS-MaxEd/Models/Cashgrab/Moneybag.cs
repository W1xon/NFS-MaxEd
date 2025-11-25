using System.Text.RegularExpressions;

namespace NFSMaxEd.Models;

public class Moneybag : BaseEntity
{
    private float _positionX, _positionY, _positionZ;
    private EntityType _selectedType;
    
    public Moneybag(EntityType moneybagType, string initialName = "") : base(initialName)
    {
        SelectedType = moneybagType;
    }
    public float PositionX { get => _positionX; set => Set(ref _positionX, value); }
    public float PositionY { get => _positionY; set => Set(ref _positionY, value); }
    public float PositionZ { get => _positionZ; set => Set(ref _positionZ, value); }

    public EntityType SelectedType
    {
        get => _selectedType;
        set => Set(ref _selectedType, value);

    }
}