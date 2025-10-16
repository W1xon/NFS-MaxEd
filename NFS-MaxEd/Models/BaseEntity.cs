namespace NFSMaxEd.Models;

public class BaseEntity : ObservableObject
{
    protected BaseEntity(string initialName = "")
    {
        _name = initialName;
    }
    private EntityType _entityType;
    private string _name;
    private bool _template;
    
    public EntityType EntityType { get => _entityType; set => Set(ref _entityType, value); }
    public string Name { get => _name; set => Set(ref _name, value); }
    public bool Template { get => _template; set => Set(ref _template, value); }
}