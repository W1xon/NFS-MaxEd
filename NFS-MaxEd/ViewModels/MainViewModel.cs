using System.ComponentModel;
using System.Runtime.CompilerServices;
using NFSMaxEd.Models;

using Barrier = NFSMaxEd.Models.Barrier;

namespace NFSMaxEd.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly RaceConfig _config = new();
    public RaceConfig Config => _config;
    public BlacklistConfig Blacklist { get; } = new();
    
    private static MainViewModel _instance;
    public static MainViewModel Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MainViewModel();
            return _instance;
        }
    }
    private MainViewModel()
    {
        Config.AddBarrierCommand = new RelayCommand(_ => Config.Barriers.Add(new Barrier()));
        Config.RemoveBarrierCommand = new RelayCommand(p => { if (p is Barrier b) Config.Barriers.Remove(b); });

        Config.AddOpponentCommand = new RelayCommand(_ =>
        {
            var newOpponent = new Opponent();
            Config.OpponentPaths.Add(newOpponent);
            UpdateNames(Config.OpponentPaths, Config.RaceBin == "race_bin_15" ? "opponent" : "character");
        });

        Config.RemoveOpponentCommand = new RelayCommand(p =>
        {
            if (p is Opponent o)
            {
                Config.OpponentPaths.Remove(o);
                UpdateNames(Config.OpponentPaths, Config.RaceBin == "race_bin_15" ? "opponent" : "character");
            }
        });

        Config.AddCheckpointCommand = new RelayCommand(_ =>
        {
            var newCheckpoint = new CheckpointEntry();
            Config.Checkpoints.Add(newCheckpoint);
            UpdateNames(Config.Checkpoints, "checkpoints");
        });

        Config.RemoveCheckpointCommand = new RelayCommand(p =>
        {
            if (p is CheckpointEntry c)
            {
                Config.Checkpoints.Remove(c);
                UpdateNames(Config.Checkpoints, "checkpoints");
            }
        });

        Config.AddShortcutCommand = new RelayCommand(_ =>
        {
            var newShortcut = new ShortcutEntry();
            Config.Shortcuts.Add(newShortcut);
            UpdateNames(Config.Shortcuts, "shortcut");
        });

        Config.RemoveShortcutCommand = new RelayCommand(p =>
        {
            if (p is ShortcutEntry s)
            {
                Config.Shortcuts.Remove(s);
                UpdateNames(Config.Shortcuts, "shortcut");
            }
        });
        _config.PropertyChanged += Config_PropertyChanged;
        UpdateVisibility();
        
        
        Blacklist.AddBossRaceCommand = new RelayCommand(_ => Blacklist.BossRaces.Add(string.Empty));
        Blacklist.RemoveBossRaceCommand = new RelayCommand(p =>
        {
            if (p is string s) Blacklist.BossRaces.Remove(s);
        });
    
        Blacklist.AddChildCommand = new RelayCommand(_ => Blacklist.Children.Add(string.Empty));
        Blacklist.RemoveChildCommand = new RelayCommand(p =>
        {
            if (p is string s) Blacklist.Children.Remove(s);
        });
    
        Blacklist.AddWorldRaceCommand = new RelayCommand(_ => Blacklist.WorldRaces.Add(string.Empty));
        Blacklist.RemoveWorldRaceCommand = new RelayCommand(p =>
        {
            if (p is string s) Blacklist.WorldRaces.Remove(s);
        });
    }

    private void Config_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(RaceConfig.NodeType))
        {
            UpdateVisibility();
        }
    }

    private void UpdateVisibility()
    {
        Config.IsCircuitOrKnockout = Config.NodeType is "circuit" or "lapknockout";
        Config.IsTollbooth = Config.NodeType == "tollboothrace";
        Config.IsSpeedtrap = Config.NodeType == "speedtraprace";
        Config.IsDrag = Config.NodeType == "drag";    
        Config.IsShortcutAvailable = Config.NodeType is "circuit" or "p2p" or "lapknockout" or "tollboothrace" or "speedtraprace";
    }
    private void UpdateNames<T>(IList<T> list, string baseName) where T : class
    {
        for (int i = 0; i < list.Count; i++)
        {
            dynamic item = list[i];
            item.Path = $"{baseName}{i + 1}";
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}