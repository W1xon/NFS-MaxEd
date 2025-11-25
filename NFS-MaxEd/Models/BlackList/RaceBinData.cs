using System.Collections.ObjectModel;

namespace NFSMaxEd.Models;

public class RaceBinData
{
    public ObservableCollection<string> BossRaces { get; set; } = [];
    public ObservableCollection<string> Children { get; set; } = [];
    public ObservableCollection<string> WorldRaces { get; set; } = [];
    public ObservableCollection<string> Milestones { get; set; } = [];
}