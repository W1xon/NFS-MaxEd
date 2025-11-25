namespace NFSMaxEd.Models;

public class CharacterDrug : BaseEntity
{
    
    private string[] _carTypes = ["trafpizza", "trafficcoup", "trafsuva"];
    private bool _fecompressionstoggle = true;
    private string _selectedCarType;
    
    public CharacterDrug(string initialName = "") : base(initialName)
    {
        SelectedCarType = CarTypes[0];
    }
    public string[] CarTypes { get => _carTypes; set => Set(ref _carTypes, value); }
    public string SelectedCarType { get => _selectedCarType; set => Set(ref _selectedCarType, value); }
    public bool Faceompressionstoggle { get => _fecompressionstoggle; set => Set(ref _fecompressionstoggle, value); }
}