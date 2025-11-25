namespace NFSMaxEd.Models;

public class Barrier : ObservableObject
{
    private string _value;
    public string Value
    {
        get => _value;
        set => Set(ref _value, value);
    }

    public Barrier(string initialValue = "") => _value = initialValue;
}
