using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NFSMaxEd.Models;

public class BlacklistConfig : ObservableObject
{
    public BlacklistConfig()
    {
        if (RaceBins.Count > 0)
            RaceBin = RaceBins[0]; 
    }

    public ObservableCollection<string> RaceBins { get; } = new() {
        "race_bin_01","race_bin_02","race_bin_03","race_bin_04","race_bin_05",
        "race_bin_06","race_bin_07","race_bin_08","race_bin_09","race_bin_10",
        "race_bin_11","race_bin_12","race_bin_13","race_bin_14","race_bin_15",
    };

    public ObservableCollection<StringWrapper> BossRaces { get; } = [];
    public ObservableCollection<StringWrapper> Children { get; } = [];
    public ObservableCollection<StringWrapper> WorldRaces { get; } = [];
    public ObservableCollection<StringWrapper> Milestones { get; } = [];

    private readonly BlacklistStore _blacklistStore = new();

    private string _raceBin;
    public string RaceBin
    {
        get => _raceBin;
        set
        {
            if (_raceBin == value) return;
            _raceBin = value;
            OnPropertyChanged();

            UpdateCollectionsForRaceBin(_raceBin);
        }
    }

    private void UpdateCollectionsForRaceBin(string raceBin)
    {
        var data = _blacklistStore.GetData(raceBin);

        BossRaces.Clear();
        foreach (var item in data.BossRaces)
            BossRaces.Add(item);

        Children.Clear();
        foreach (var item in data.Children)
            Children.Add(item);

        WorldRaces.Clear();
        foreach (var item in data.WorldRaces)
            WorldRaces.Add(item);
        Milestones.Clear();
        foreach (var item in data.Milestones)
            Milestones.Add(item);

        OnPropertyChanged(nameof(BossRaces));
        OnPropertyChanged(nameof(Children));
        OnPropertyChanged(nameof(WorldRaces));
        OnPropertyChanged(nameof(Milestones));
    }


    private int _requiredBounty;
    public int RequiredBounty
    {
        get => _requiredBounty;
        set
        {
            if (_requiredBounty == value) return;
            _requiredBounty = value;
            OnPropertyChanged();
        }
    }

    private int _requiredChallenges;
    public int RequiredChallenges
    {
        get => _requiredChallenges;
        set
        {
            if (_requiredChallenges == value) return;
            _requiredChallenges = value;
            OnPropertyChanged();
        }
    }

    private int _requiredRaceWon;
    public int RequiredRaceWon
    {
        get => _requiredRaceWon;
        set
        {
            if (_requiredRaceWon == value) return;
            _requiredRaceWon = value;
            OnPropertyChanged();
        }
    }

    public void Reset()
    {
        RequiredBounty = 0;
        RequiredChallenges = 0;
        RequiredRaceWon = 0;

        RaceBin = RaceBins[0];
    }

    public ICommand AddBossRaceCommand { get; set; }
    public ICommand RemoveBossRaceCommand { get; set; }

    public ICommand AddChildCommand { get; set; }
    public ICommand RemoveChildCommand { get; set; }

    public ICommand AddWorldRaceCommand { get; set; }
    public ICommand RemoveWorldRaceCommand { get; set; }
    public ICommand AddMilestoneCommand { get; set; }
    public ICommand RemoveMilestoneCommand { get; set; }
}