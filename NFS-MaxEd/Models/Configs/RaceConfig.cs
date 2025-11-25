using System.Collections.ObjectModel;
using System.Windows.Input;
using NFSMaxEd.Extensions;

namespace NFSMaxEd.Models;

public class RaceConfig : ObservableObject
{
    public RaceConfig()
    {
        Region = Regions.Count > 0 ? Regions[0] : string.Empty;
        RaceBin = RaceBins.Count > 0 ? RaceBins[0] : string.Empty;
        NodeType = NodeTypes.Count > 0 ? NodeTypes[0] : RaceType.circuit;
        IntroNis = IntroNisList.Count > 0 ? IntroNisList[0] : string.Empty;
        FinishCamera = FinishCameraList.Count > 0 ? FinishCameraList[0] : string.Empty;

        // Инициализация стартовой сетки и финишной линии
        StartGrid = new PointEntity(EntityType.startgrid)
        {
            Name = "startgrid",
            PositionX = 0,
            PositionY = 0,
            PositionZ = 0,
            Rotation = 0,
            Template = true
        };

        FinishLine = new PointEntity(EntityType.finishline)
        {
            Name = "finishline",
            Template = true
        };

        StartMarker = new PointEntity(EntityType.marker)
        {
            Name = "start_marker",
            Template = true
        };

        FinishMarker = new PointEntity(EntityType.marker)
        {
            Name = "finish_marker",
            Template = true
        };
    }

    public int GetChildrenCount()
    {
        int count = Shortcuts.Count + 
                                   Checkpoints.Count + 
                                   Speedtraps.Count + 
                                   CharacterDrugs.Count +
                                   Moneybags.Count +
                                   CashgrabCharacters.Count + 
                                   CashgrabOpponentSpawns.Count + 
                                   ResetPlayerTrigers.Count;

        int adding = 0;
        adding += NodeType == RaceType.cashgrab ? 1: 2;
        adding += NodeType == RaceType.drag ? 2 : 0;
        return count + adding;
    }
    // ─────────────── Списки опций ───────────────
    public ObservableCollection<string> Regions { get; } = ["college", "coastal", "city"];
    public ObservableCollection<string> RaceBins { get; } =
    [
        "race_bin_01", "race_bin_02", "race_bin_03", "race_bin_04", "race_bin_05",
        "race_bin_06", "race_bin_07", "race_bin_08", "race_bin_09", "race_bin_10",
        "race_bin_11", "race_bin_12", "race_bin_13", "race_bin_14", "race_bin_15",
        "race_bin_challenge"
    ];
    public ObservableCollection<RaceType> NodeTypes { get; } =
    [
        RaceType.circuit, RaceType.p2p, RaceType.lapknockout, RaceType.tollboothrace, RaceType.speedtraprace,
        RaceType.cashgrab, RaceType.drag
    ];
    public ObservableCollection<string> IntroNisList { get; } =
    [
        "IntroNis01", "IntroNis02", "IntroNis03", "IntroNis04", "IntroNis05",
        "IntroNis06", "IntroNis07", "IntroNis08", "IntroNis09", "IntroNisBL02",
        "IntroNisBL03", "IntroNisBL04", "IntroNisBL05", "IntroNisBL06", "IntroNisBL07",
        "IntroNisBL08", "IntroNisBL09", "IntroNisBL10", "IntroNisBL11", "IntroNisBL12",
        "IntroNisBL13", "IntroNisBL14", "IntroNisBL15", "IntroNisBL16",
    ];
    public ObservableCollection<string> FinishCameraList { get; } =
    [
        "PHoldFin_01", "PHoldFin_02", "PHoldFin_03", "PHoldFin_04", "PHoldFin_05",
        "PHoldFin_06", "PHoldFin_07", "PHoldFin_08", "PHoldFin_09", "PHoldFin_10",
        "PHoldFin_11", "PHoldFin_12", "PHoldFin_13", "PHoldFin_14", "PHoldFin_15",
        "PHoldFin_16", "PHoldFin_17", "PHoldFin_18", "PHoldFin_19", "PHoldFin_20",
        "PHoldFin_21", "PHoldFin_22", "PHoldFin_23", "PHoldFin_24", "PHoldFin_25",
        "PHoldFin_26", "PHoldFin_27", "PHoldFin_28", "PHoldFin_29"
    ];

    // ─────────────── Свойства выбора ───────────────
        private string _region;
        public string Region { get => _region; set => Set(ref _region, value); }

        private string _raceBin;
        public string RaceBin { get => _raceBin; set => Set(ref _raceBin, value); }

        private RaceType _nodeType;
        public RaceType NodeType { get => _nodeType; set => Set(ref _nodeType, value); }

        private string _introNis;
        public string IntroNis { get => _introNis; set => Set(ref _introNis, value); }

        private string _finishCamera;
        public string FinishCamera { get => _finishCamera; set => Set(ref _finishCamera, value); }

        private string _template = string.Empty;
        public string Template { get => _template; set => Set(ref _template, value); }

        private int _trafficLevel;
        public int TrafficLevel { get => _trafficLevel; set => Set(ref _trafficLevel, value); }
        
        private double _rivalBestTime;
        public double RivalBestTime
        {
            get => _rivalBestTime;
            set => Set(ref _rivalBestTime, value);
        }
        private string _postRaceActivity;
        public string PostRaceActivity
        {
            get => _postRaceActivity;
            set => Set(ref _postRaceActivity, value);
        }

        private int _forceHeatLevel;
        public int ForceHeatLevel
        {
            get => _forceHeatLevel;
            set => Set(ref _forceHeatLevel, value);
        }

        private int _maxHeatLevel;

        public int MaxHeatLevel
        {
            get => _maxHeatLevel;
            set => Set(ref _maxHeatLevel, value);
        }
            
        public string Path => $"{RaceBin}/{GameplayVault}";

        // Флаги
        private bool _bossRaces;
        public bool BossRaces 
        {
            get => _bossRaces;
            set
            {
                 Opponent = 1;
                 Set(ref _bossRaces, value);
            }
        }

        private bool _availableQR;
        public bool AvailableQR { get => _availableQR; set => Set(ref _availableQR, value); }

        private bool _enableCops;
        public bool EnableCops { get => _enableCops; set => Set(ref _enableCops, value); }

        private bool _quickRaceNis;
        public bool QuickRaceNis { get => _quickRaceNis; set => Set(ref _quickRaceNis, value); }

        // Параметры гонки
        private int _cashValue;
        public int CashValue { get => _cashValue; set => Set(ref _cashValue, value); }
        private bool _isChanceOfRain;

        public bool IsChanceOfRain
        {
            get => _isChanceOfRain;
            set => Set(ref _isChanceOfRain, value);
        }
        private int _chanceOfRain;

        public int ChanceOfRain
        {
            get => _chanceOfRain;
            set
            {
                if (value > 1)
                    Set(ref _chanceOfRain, 1);
                else if (value < -1)
                    Set(ref _chanceOfRain, -1);
                else
                    Set(ref _chanceOfRain, value);
            }
        }

        private string _gameplayVault;
        public string GameplayVault { get => _gameplayVault; set => Set(ref _gameplayVault, value); }

        private int _raceLength;
        public int RaceLength { get => _raceLength; set => Set(ref _raceLength, value); }
        
        private int _opponent;
        public int Opponent
        {
            get => _opponent;
            set
            {
                if (BossRaces)
                {
                    value = 1;
                    Set(ref _opponent, value);
                }
                if(value > 3)
                    Set(ref _opponent, 3);
                else
                    Set(ref _opponent, value);
                
                if (NodeType != RaceType.cashgrab) return;
                CashgrabOpponentSpawns.Clear();
                for (int i = 0; i < _opponent; i++)
                {
                    CashgrabOpponentSpawns.Add(new PointEntity(EntityType.carmarker));
                }
                CashgrabOpponentSpawns.UpdateNames("opponent_spawn");
            }
        }
        
        // Старт / Финиш
        private PointEntity _startGrid;
        public PointEntity StartGrid { get => _startGrid; set => Set(ref _startGrid, value); }
        private PointEntity _finishLine;
        public PointEntity FinishLine { get => _finishLine; set => Set(ref _finishLine, value); }
        

        private string _eventId;
        public string EventId { get => _eventId; set => Set(ref _eventId, value); }
        // Специфичные параметры для гонок
        private int _numLaps;
        public int NumLaps { get => _numLaps; set => Set(ref _numLaps, value); }

        private int _timeLimit;
        public int TimeLimit { get => _timeLimit; set => Set(ref _timeLimit, value); }
        
        private int _reputation;
        public int Reputation {get => _reputation; set => Set(ref _reputation, value);}

        private int _initialSpeed;
        public int InitialSpeed
        {
            get => _initialSpeed;
            set => Set(ref _initialSpeed, value);
        }

        private int _cashRewards;
        public int CashRewards
        {
            get => _cashRewards;
            set => Set(ref _cashRewards, value);
        }

        private int _skillLevel;

        public int SkillLevel
        {
            get => _skillLevel;
            set => Set(ref _skillLevel, value);
        }

        private PointEntity _startMarker;
        public PointEntity StartMarker { get => _startMarker; set => Set(ref _startMarker, value); }
        private PointEntity _finishMarker;
        public PointEntity FinishMarker { get => _finishMarker; set => Set(ref _finishMarker, value); }
        
        public List<BaseEntity> GenerateOpponents()
        {
            var list = new List<BaseEntity>();

            for (int i = 0; i < Opponent; i++)
            {
                list.Add(new BaseEntity
                {
                    EntityType = EntityType.character,
                    Template = true
                });
            }

            list.UpdateNames(RaceBin == "race_bin_15" ? "opponent" : "character");
            return list;
        }

        public List<CharacterCashgrab> GenerateCashgrabOpponents()
        {
            
            var list = new List<CharacterCashgrab>();

            for (int i = 0; i < Opponent; i++)
            {
                list.Add(new CharacterCashgrab
                {
                    EntityType = EntityType.character,
                    Template = true
                });
            }

            list.UpdateNames("opponent");
            return list;
        }
        // Коллекции
        public ObservableCollection<Barrier> Barriers { get; } = [];
        public ObservableCollection<CheckpointEntity> Checkpoints { get; } = [];
        public ObservableCollection<SpeedtrapEntity> Speedtraps { get; } = [];
        public ObservableCollection<CharacterDrug> CharacterDrugs { get; } = [];
        public ObservableCollection<string> ChildrenPaths { get; } = [];
        public ObservableCollection<ShortcutEntity> Shortcuts { get; } = [];
        public ObservableCollection<TrafficSpawnTrigger> TrafficSpawnTriggers { get; } = [];
        public ObservableCollection<PointEntity> ResetPlayerTrigers { get; } = [];
        public ObservableCollection<Moneybag> Moneybags { get; } = [];
        private List<BaseEntity> _opponents = [];
        public List<BaseEntity> Opponents
        {
            get
            {
                if (NodeType != RaceType.cashgrab)
                    _opponents = GenerateOpponents();
                return _opponents;
            }
        }

        private List<CharacterCashgrab> _cashgrabCharacters = [];
        public List<CharacterCashgrab> CashgrabCharacters
        {
            get
            {
                if (_cashgrabCharacters.Count != Opponent && NodeType == RaceType.cashgrab)
                    _cashgrabCharacters = GenerateCashgrabOpponents();
                return _cashgrabCharacters;
            }
        } 
        public ObservableCollection<PointEntity> CashgrabOpponentSpawns  { get; } = [];

        private bool _isCircuitOrKnockout;
        private bool _isTollbooth;
        private bool _isSpeedtrap;
        private bool _isDrag;
        private bool _isShortcutAvailable;
        private bool _isFinishAvailable;
        private bool _isCashgrab;
        public bool IsCircuitOrKnockout
        {
            get => _isCircuitOrKnockout;
            set => Set(ref _isCircuitOrKnockout, value);
        }
     
        public bool IsTollbooth
        {
            get => _isTollbooth;
            set => Set(ref _isTollbooth, value);
        }
     
        public bool IsSpeedtrap
        {
            get => _isSpeedtrap;
            set => Set(ref _isSpeedtrap, value);
        }
     
        public bool IsDrag
        {
            get => _isDrag;
            set => Set(ref _isDrag, value);
        }
        public bool IsShortcutAvailable
        {
            get => _isShortcutAvailable;
            set => Set(ref _isShortcutAvailable, value);
        }

        public bool IsFinishAvailable
        {
            get => _isFinishAvailable;
            set => Set(ref _isFinishAvailable, value);
        }

        public bool IsCashgrab
        {
            get => _isCashgrab;
            set => Set(ref _isCashgrab, value);
        }
        public void Reset()
        {
            Region = Regions.FirstOrDefault() ?? string.Empty;
            RaceBin = RaceBins.FirstOrDefault() ?? string.Empty;
            IntroNis = IntroNisList.FirstOrDefault() ?? string.Empty;
            FinishCamera = FinishCameraList.FirstOrDefault() ?? string.Empty;
        
            TrafficLevel = 0;
            RivalBestTime = 0;
            PostRaceActivity = string.Empty;
            ForceHeatLevel = 0;
            MaxHeatLevel = 0;
            BossRaces = false;
            AvailableQR = false;
            EnableCops = false;
            QuickRaceNis = false;
            CashValue = 0;
            IsChanceOfRain = false;
            ChanceOfRain = 0;
            GameplayVault = string.Empty;
            RaceLength = 0;
            Opponent = 0;
            EventId = string.Empty;
            NumLaps = 0;
            TimeLimit = 0;
            Reputation = 0;
            InitialSpeed = 0;
            CashRewards = 0;
            SkillLevel = 0;
        
            // Очистка коллекций
            Barriers.Clear();
            Checkpoints.Clear();
            Speedtraps.Clear();
            CharacterDrugs.Clear();
            Shortcuts.Clear();
            TrafficSpawnTriggers.Clear();
            ResetPlayerTrigers.Clear();
            Moneybags.Clear();
            CashgrabCharacters.Clear();
            CashgrabOpponentSpawns.Clear();
            Opponents.Clear();
        
            // Пересоздание стартовых объектов
            StartGrid = new PointEntity(EntityType.startgrid) { Name = "startgrid", Template = true };
            FinishLine = new PointEntity(EntityType.finishline) { Name = "finishline", Template = true };
            StartMarker = new PointEntity(EntityType.marker) { Name = "start_marker", Template = true };
            FinishMarker = new PointEntity(EntityType.marker) { Name = "finish_marker", Template = true };
        
            // Сброс флагов типа гонки
            IsCircuitOrKnockout = false;
            IsTollbooth = false;
            IsSpeedtrap = false;
            IsDrag = false;
            IsShortcutAvailable = false;
            IsFinishAvailable = false;
            IsCashgrab = false;
        }

        public ICommand AddBarrierCommand { get; set; }
        public ICommand RemoveBarrierCommand { get; set;}
        public ICommand AddCheckpointCommand { get; set;}
        public ICommand RemoveCheckpointCommand { get; set;}
        public ICommand AddShortcutCommand { get; set;}
        public ICommand RemoveShortcutCommand { get; set;}
        public ICommand AddSpeedtrapCommand { get; set; }
        public ICommand RemoveSpeedtrapCommand { get; set; }
        public ICommand AddCharacterDrugCommand { get; set; }
        public ICommand RemoveCharacterDrugCommand { get; set; }
        public ICommand AddTimeBonusCheckpointCommand { get; set; }
        
        public ICommand AddResetPlayerTriggerCommand { get; set;}
        public ICommand RemoveResetPlayerTriggerCommand { get; set;}
        public ICommand AddMoneybagSmallCommand { get; set; }
        public ICommand AddMoneybagMiddleCommand { get; set; }
        public ICommand AddMoneybagBigCommand { get; set; }
        public ICommand RemoveMoneybag { get; set; }
}
