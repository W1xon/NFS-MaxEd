using System.Collections.ObjectModel;

namespace NFSMaxEd.Models;

public class RaceBinData
{
    public ObservableCollection<string> BossRaces { get; set; } = new();
    public ObservableCollection<string> Children { get; set; } = new();
    public ObservableCollection<string> WorldRaces { get; set; } = new();
}