using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NFSMaxEd.Models;

public class RaceConfig : INotifyPropertyChanged
{
    public RaceConfig()
    {
        Region = Regions.Count > 0 ? Regions[0] : string.Empty;
        RaceBin = RaceBins.Count > 0 ? RaceBins[0] : string.Empty;
        NodeType = NodeTypes.Count > 0 ? NodeTypes[0] : string.Empty;
        IntroNis = IntroNisList.Count > 0 ? IntroNisList[0] : string.Empty;
        FinishCamera = FinishCameraList.Count > 0 ? FinishCameraList[0] : string.Empty;

        StartGrid = new StartGrid
        {
            Path = "startgrid",
            PositionX = 0,
            PositionY = 0,
            PositionZ = 0,
            Rotation = 0,
            Template = true
        };

        FinishLine = new FinishLine
        {
            Path = "finishline",
            PositionX = 0,
            PositionY = 0,
            PositionZ = 0,
            Rotation = 0,
            Template = true
        };
    }

    public ObservableCollection<string> Regions { get; } = new() { "college", "coastal", "city" };
    public ObservableCollection<string> RaceBins { get; } = new() {
        "race_bin_01","race_bin_02","race_bin_03","race_bin_04","race_bin_05",
        "race_bin_06","race_bin_07","race_bin_08","race_bin_09","race_bin_10",
        "race_bin_11","race_bin_12","race_bin_13","race_bin_14","race_bin_15",
        "race_bin_challenge", "race_bin_16"
    };
    public ObservableCollection<string> NodeTypes { get; } = new() {"circuit", "p2p",   "lapknockout", "tollboothrace", "speedtraprace", "cashgrab", "drag" };
    public ObservableCollection<string> IntroNisList { get; } = new() {
        "IntroNis01","IntroNis02","IntroNis03","IntroNis04","IntroNis05",
        "IntroNis06","IntroNis07","IntroNis08","IntroNis09"
    };
    public ObservableCollection<string> FinishCameraList { get; } = new() {
        "PHoldFin_01","PHoldFin_02","PHoldFin_03","PHoldFin_04","PHoldFin_05",
        "PHoldFin_06","PHoldFin_07","PHoldFin_08","PHoldFin_09","PHoldFin_10",
        "PHoldFin_11","PHoldFin_12","PHoldFin_13","PHoldFin_14","PHoldFin_15",
        "PHoldFin_16","PHoldFin_17","PHoldFin_18","PHoldFin_19","PHoldFin_20",
        "PHoldFin_21","PHoldFin_22","PHoldFin_23","PHoldFin_24","PHoldFin_25",
        "PHoldFin_26","PHoldFin_27","PHoldFin_28","PHoldFin_29"
    };

        private string _region;
        public string Region { get => _region; set => Set(ref _region, value); }

        private string _raceBin;
        public string RaceBin { get => _raceBin; set => Set(ref _raceBin, value); }

        private string _nodeType;
        public string NodeType { get => _nodeType; set => Set(ref _nodeType, value); }

        private string _introNis;
        public string IntroNis { get => _introNis; set => Set(ref _introNis, value); }

        private string _finishCamera;
        public string FinishCamera { get => _finishCamera; set => Set(ref _finishCamera, value); }

        private string _template = string.Empty;
        public string Template { get => _template; set => Set(ref _template, value); }

        private int _trafficLevel;
        public int TrafficLevel { get => _trafficLevel; set => Set(ref _trafficLevel, value); }

        public string Path => $"{RaceBin}/{GameplayVault}";

        private bool _availableOnline;
        public bool AvailableOnline { get => _availableOnline; set => Set(ref _availableOnline, value); }

        private bool _availableQR;
        public bool AvailableQR { get => _availableQR; set => Set(ref _availableQR, value); }

        private bool _enableCops;
        public bool EnableCops { get => _enableCops; set => Set(ref _enableCops, value); }

        private bool _quickRaceNis;
        public bool QuickRaceNis { get => _quickRaceNis; set => Set(ref _quickRaceNis, value); }

        private int _cashValue;
        public int CashValue { get => _cashValue; set => Set(ref _cashValue, value); }

        private float _chanceOfRain;
        public float ChanceOfRain { get => _chanceOfRain; set => Set(ref _chanceOfRain, value); }

        private string _gameplayVault;
        public string GameplayVault { get => _gameplayVault; set => Set(ref _gameplayVault, value); }

        private int _raceLength;
        public int RaceLength { get => _raceLength; set => Set(ref _raceLength, value); }

        
        public StartGrid StartGrid { get; set; }
        public FinishLine FinishLine { get; set; }

        private string _eventId;
        public string EventId { get => _eventId; set => Set(ref _eventId, value); }

        // Специфичные параметры для гонок
        private int _numLaps;
        public int NumLaps { get => _numLaps; set => Set(ref _numLaps, value); }

        private int _timeLimit;
        public int TimeLimit { get => _timeLimit; set => Set(ref _timeLimit, value); }

        public ObservableCollection<string> SpeedTrapList { get; } = new ObservableCollection<string>();

        private string _randomSpawnTriggers;
        public string RandomSpawnTriggers { get => _randomSpawnTriggers; set => Set(ref _randomSpawnTriggers, value); }

        // Дополнительные параметры
        private int _forceHeatLevel;
        public int ForceHeatLevel { get => _forceHeatLevel; set => Set(ref _forceHeatLevel, value); }

        private int _maxHeatLevel;
        public int MaxHeatLevel { get => _maxHeatLevel; set => Set(ref _maxHeatLevel, value); }

        private string _eventIconType;
        public string EventIconType { get => _eventIconType; set => Set(ref _eventIconType, value); }

        private int _progressionLevel;
        public int ProgressionLevel { get => _progressionLevel; set => Set(ref _progressionLevel, value); }

        private string _targetBronzeGold;
        public string TargetBronzeGold { get => _targetBronzeGold; set => Set(ref _targetBronzeGold, value); }

        // Коллекции
        public ObservableCollection<Barrier> Barriers { get; } = new ObservableCollection<Barrier>();
        public ObservableCollection<CheckpointEntry> Checkpoints { get; } = new ObservableCollection<CheckpointEntry>();
        public ObservableCollection<string> ChildrenPaths { get; } = new ObservableCollection<string>();
        public ObservableCollection<Opponent> OpponentPaths { get; } = new ObservableCollection<Opponent>();
        public ObservableCollection<ShortcutEntry> Shortcuts { get; } = new ObservableCollection<ShortcutEntry>();
        
        
        private bool _isCircuitOrKnockout;
        private bool _isTollbooth;
        private bool _isSpeedtrap;
        private bool _isDrag;
        private bool _isShortcutAvailable;
     
        public bool IsCircuitOrKnockout
        {
            get => _isCircuitOrKnockout;
            set { _isCircuitOrKnockout = value; OnPropertyChanged(); }
        }
     
        public bool IsTollbooth
        {
            get => _isTollbooth;
            set { _isTollbooth = value; OnPropertyChanged(); }
        }
     
        public bool IsSpeedtrap
        {
            get => _isSpeedtrap;
            set { _isSpeedtrap = value; OnPropertyChanged(); }
        }
     
        public bool IsDrag
        {
            get => _isDrag;
            set { _isDrag = value; OnPropertyChanged(); }
        }
        public bool IsShortcutAvailable
        {
            get => _isShortcutAvailable;
            set { _isShortcutAvailable = value; OnPropertyChanged(); }
        }
        
        
        

    
    
        public ICommand AddBarrierCommand { get; set; }
        public ICommand RemoveBarrierCommand { get; set;}
        public ICommand AddCheckpointCommand { get; set;}
        public ICommand RemoveCheckpointCommand { get; set;}
        public ICommand AddOpponentCommand { get;set; }
        public ICommand RemoveOpponentCommand { get; set;}
        public ICommand AddShortcutCommand { get; set;}
        public ICommand RemoveShortcutCommand { get; set;}
        
        
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private void Set<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(name);
            }
        }
}
