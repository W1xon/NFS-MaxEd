namespace NFSMaxEd.Models;

public class Opponent : ObservableObject
{
    private string _path;
    public string Path
    {
        get => _path;
        set => SetProperty(ref _path, value);
    }

    public Opponent(string initialPath = "") => _path = initialPath;
}