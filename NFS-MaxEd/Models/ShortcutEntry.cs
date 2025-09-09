namespace NFSMaxEd.Models;

public class ShortcutEntry : ObservableObject
{
    private string _path = string.Empty;
    private double _maxChance = 1.0;
    private double _minChance = 0.5;
    private double _posX, _posY, _posZ;
    private double _rotation;
    private bool _template;

    public ShortcutEntry(string initialPath = "") => _path = initialPath;

    public string Path { get => _path; set => SetProperty(ref _path, value); }
    public double MaxChance { get => _maxChance; set => SetProperty(ref _maxChance, value); }
    public double MinChance { get => _minChance; set => SetProperty(ref _minChance, value); }
    public double PositionX { get => _posX; set => SetProperty(ref _posX, value); }
    public double PositionY { get => _posY; set => SetProperty(ref _posY, value); }
    public double PositionZ { get => _posZ; set => SetProperty(ref _posZ, value); }
    public double Rotation { get => _rotation; set => SetProperty(ref _rotation, value); }
    public bool Template { get => _template; set => SetProperty(ref _template, value); }
}