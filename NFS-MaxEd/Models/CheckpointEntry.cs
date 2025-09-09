using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFSMaxEd.Models;

public class CheckpointEntry : ObservableObject
{
    private string _path;
    private float _positionX, _positionY, _positionZ;
    private float _rotation;
    private bool _template;

    public CheckpointEntry(string initialPath = "") => _path = initialPath;

    public string Path { get => _path; set => SetProperty(ref _path, value); }
    public float PositionX { get => _positionX; set => SetProperty(ref _positionX, value); }
    public float PositionY { get => _positionY; set => SetProperty(ref _positionY, value); }
    public float PositionZ { get => _positionZ; set => SetProperty(ref _positionZ, value); }
    public float Rotation { get => _rotation; set => SetProperty(ref _rotation, value); }
    public bool Template { get => _template; set => SetProperty(ref _template, value); }
}