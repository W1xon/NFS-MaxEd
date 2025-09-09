using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NFSMaxEd.Models;

public class BlacklistConfig : INotifyPropertyChanged
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

    public ObservableCollection<StringWrapper> BossRaces { get; } = new();
    public ObservableCollection<StringWrapper> Children { get; } = new();
    public ObservableCollection<StringWrapper> WorldRaces { get; } = new();

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

        // Очищаем и заполняем коллекции
        BossRaces.Clear();
        foreach (var item in data.BossRaces)
            BossRaces.Add(item);

        Children.Clear();
        foreach (var item in data.Children)
            Children.Add(item);

        WorldRaces.Clear();
        foreach (var item in data.WorldRaces)
            WorldRaces.Add(item);

        // Уведомляем UI об изменении коллекций
        OnPropertyChanged(nameof(BossRaces));
        OnPropertyChanged(nameof(Children));
        OnPropertyChanged(nameof(WorldRaces));
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

    public ICommand AddBossRaceCommand { get; set; }
    public ICommand RemoveBossRaceCommand { get; set; }

    public ICommand AddChildCommand { get; set; }
    public ICommand RemoveChildCommand { get; set; }

    public ICommand AddWorldRaceCommand { get; set; }
    public ICommand RemoveWorldRaceCommand { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}