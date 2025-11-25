using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NFSMaxEd.Extensions;
using NFSMaxEd.Models;
using Barrier = NFSMaxEd.Models.Barrier;

namespace NFSMaxEd.ViewModels;

public class MainViewModel : ObservableObject
{
   private RaceConfig _config = new();
   public RaceConfig Config
   {
       get => _config;
       set => Set(ref _config, value);
   }
   
   private BlacklistConfig _blacklist = new();
   public BlacklistConfig Blacklist
   {
       get => _blacklist;
       set => Set(ref _blacklist, value);
   }
   
   private MilestoneConfig _milestoneConfig = new();
   public MilestoneConfig MilestoneConfig
   {
       get => _milestoneConfig;
       set => Set(ref _milestoneConfig, value);
   }


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
    public void ResetConfigs()
    {
        Config.Reset();
        Blacklist.Reset();
        MilestoneConfig.Reset();
    }



    private MainViewModel()
    {
        InitializeConfigCommands();
        InitializeBlacklistCommands();
        _config.PropertyChanged += Config_PropertyChanged;
        UpdateVisibility();
    }

    #region Config Commands Initialization

    private void InitializeConfigCommands()
    {
        InitializeBarrierCommands();
        InitializeCheckpointCommands();
        InitializeTimeBonusCheckpoint();
        InitializeShortcutCommands();
        InitializeSpeedtrapCommands();
        InitializeCharacterDrugCommands();
        InitializeResetPlayerTriggerCommands();
        InitializeMoneybagCommands();
    }

    private void InitializeMoneybagCommands()
    {
        Config.AddMoneybagSmallCommand = CreateAddCommand(Config.Moneybags, ()=> new Moneybag(EntityType.moneybag_small), "moneybag_small");
        Config.AddMoneybagMiddleCommand = CreateAddCommand(Config.Moneybags, ()=> new Moneybag(EntityType.moneybag_middle), "moneybag_middle");
        Config.AddMoneybagBigCommand = CreateAddCommand(Config.Moneybags, ()=> new Moneybag(EntityType.moneybag_big), "moneybag_big");
        
        Config.RemoveMoneybag = new RelayCommand(p =>
        {
            if (p is not Moneybag item) return;
            
            Config.Moneybags.Remove(item);
            if(item.Name.Contains("small"))
            {
                Config.Checkpoints.UpdateNames("moneybag_small");
            }
            else if(item.Name.Contains("middle"))
            {
                Config.Checkpoints.UpdateNames("moneybag_middle");
            }
            else if(item.Name.Contains("big"))
            {
                Config.Checkpoints.UpdateNames("moneybag_big");
            }
        });
    }

    private void InitializeResetPlayerTriggerCommands()
    {
        Config.AddResetPlayerTriggerCommand = CreateAddCommand(Config.ResetPlayerTrigers, () => new PointEntity(EntityType.resetplayertrigger), "wrongway");
        Config.RemoveResetPlayerTriggerCommand = CreateRemoveCommand(Config.ResetPlayerTrigers, "wrongway");
        
    }

    private void InitializeBarrierCommands()
    {
        Config.AddBarrierCommand = new RelayCommand(_ => Config.Barriers.Add(new Barrier()));
        Config.RemoveBarrierCommand = new RelayCommand(p =>
        {
            if (p is Barrier b) Config.Barriers.Remove(b);
        });
    }


    private void InitializeCheckpointCommands()
    {
        Config.AddCheckpointCommand = CreateAddCommand(Config.Checkpoints,
            () => new CheckpointEntity(EntityType.checkpoint), EntityType.checkpoint);
        Config.RemoveCheckpointCommand = new RelayCommand(p =>
        {
            if (p is not CheckpointEntity item) return;
            Config.Checkpoints.Remove(item);
            if(!item.Name.Contains("/"))
            {
                Config.Checkpoints.UpdateNames(item.EntityType.ToString());
            }
            else
            {
                Config.Checkpoints.UpdateNames($"/{item.EntityType.ToString()}");
            }
        });}

    private void InitializeTimeBonusCheckpoint()
    {
        Config.AddTimeBonusCheckpointCommand = CreateAddCommand(Config.Checkpoints,
            () => new CheckpointEntity(EntityType.timebonuscheckpoint), $"/{EntityType.checkpoint}");
    }

    private void InitializeShortcutCommands()
    {
        Config.AddShortcutCommand = CreateAddCommand(Config.Shortcuts, () => new ShortcutEntity(), EntityType.shortcut);
        Config.RemoveShortcutCommand = CreateRemoveCommand(Config.Shortcuts, EntityType.shortcut);
    }

    private void InitializeSpeedtrapCommands()
    {
        Config.AddSpeedtrapCommand = CreateAddCommand(Config.Speedtraps, () => new SpeedtrapEntity(), EntityType.speedtrap);
        Config.RemoveSpeedtrapCommand = CreateRemoveCommand(Config.Speedtraps, EntityType.speedtrap);
    }

    private void InitializeCharacterDrugCommands()
    {
        // Создаем CharacterDrug и связанный TrafficSpawnTrigger вместе
        Config.AddCharacterDrugCommand = new RelayCommand(_ =>
        {
            var newCharacterDrug = new CharacterDrug();
            var newTrigger = new TrafficSpawnTrigger();
            
            Config.CharacterDrugs.Add(newCharacterDrug);
            Config.TrafficSpawnTriggers.Add(newTrigger);
            
            Config.CharacterDrugs.UpdateNames("character");
            Config.TrafficSpawnTriggers.UpdateNames("trafficspawntrigger");
        });

        // Удаляем CharacterDrug и связанный TrafficSpawnTrigger по индексу
        Config.RemoveCharacterDrugCommand = new RelayCommand(p =>
        {
            int index = -1;
            
            // Определяем индекс в зависимости от типа параметра
            if (p is CharacterDrug c)
            {
                index = Config.CharacterDrugs.IndexOf(c);
            }
            else if (p is TrafficSpawnTrigger t)
            {
                index = Config.TrafficSpawnTriggers.IndexOf(t);
            }
            
            // Удаляем оба объекта по найденному индексу
            if (index >= 0)
            {
                if (index < Config.CharacterDrugs.Count)
                {
                    Config.CharacterDrugs.RemoveAt(index);
                }
                
                if (index < Config.TrafficSpawnTriggers.Count)
                {
                    Config.TrafficSpawnTriggers.RemoveAt(index);
                }
                Config.CharacterDrugs.UpdateNames("character");
                Config.TrafficSpawnTriggers.UpdateNames("trafficspawntrigger");
            }
        });
    }
    #endregion

    private void InitializeBlacklistCommands()
    {
        Blacklist.AddBossRaceCommand = CreateAddCommand(Blacklist.BossRaces);
        Blacklist.RemoveBossRaceCommand = CreateRemoveCommand(Blacklist.BossRaces);
        
        Blacklist.AddChildCommand = CreateAddCommand(Blacklist.Children);
        Blacklist.RemoveChildCommand = CreateRemoveCommand(Blacklist.Children);
        
        Blacklist.AddWorldRaceCommand = CreateAddCommand(Blacklist.WorldRaces);
        Blacklist.RemoveWorldRaceCommand = CreateRemoveCommand(Blacklist.WorldRaces);

        Blacklist.AddMilestoneCommand = CreateAddCommand(Blacklist.Milestones);
        Blacklist.RemoveMilestoneCommand = CreateRemoveCommand(Blacklist.Milestones);
    }

    
    private RelayCommand CreateAddCommand<T>(IList<T> collection, Func<T> factory, EntityType baseName = default) where T : BaseEntity
    {
        return new RelayCommand(_ =>
        {
            var item = factory();
            collection.Add(item);
            if (baseName != default)
                collection.UpdateNames(baseName.ToString());
        });
    }

    private RelayCommand CreateRemoveCommand<T>(IList<T> collection, EntityType baseName = default) where T : BaseEntity
    {
        return new RelayCommand(p =>
        {
            if (p is T item)
            {
                collection.Remove(item);
                if (baseName != default) 
                    collection.UpdateNames(baseName.ToString());
            }
        });
    }
    private RelayCommand CreateAddCommand<T>(IList<T> collection, Func<T> factory, string baseName = "") where T : BaseEntity
    {
        return new RelayCommand(_ =>
        {
            var item = factory();
            collection.Add(item);
            if (!string.IsNullOrWhiteSpace(baseName))
                collection.UpdateNames(baseName);
        });
    }

    private RelayCommand CreateRemoveCommand<T>(IList<T> collection, string baseName = "") where T : BaseEntity
    {
        return new RelayCommand(p =>
        {
            if (p is T item)
            {
                collection.Remove(item);
                if (!string.IsNullOrWhiteSpace(baseName))
                    collection.UpdateNames(baseName);
            }
        });
    }

    private RelayCommand CreateAddCommand(IList<StringWrapper> collection)
    {
        return new RelayCommand(_ => collection.Add(new StringWrapper("")));
    }
    
    private RelayCommand CreateRemoveCommand(IList<StringWrapper> collection) 
    {
        return new RelayCommand(p =>
        {
            if (p is StringWrapper item) 
                collection.Remove(item);
        });
    }
    private void Config_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(RaceConfig.NodeType))
        {
            UpdateVisibility();
        }
    }
    public  void UpdateVisibility()
    {
        Config.IsCircuitOrKnockout = Config.NodeType is RaceType.circuit or RaceType.lapknockout;
        Config.IsTollbooth = Config.NodeType == RaceType.tollboothrace;
        Config.IsSpeedtrap = Config.NodeType == RaceType.speedtraprace;
        Config.IsDrag = Config.NodeType == RaceType.drag;
        Config.IsFinishAvailable = Config.NodeType != RaceType.cashgrab;
        Config.IsCashgrab = Config.NodeType == RaceType.cashgrab;
        Config.IsShortcutAvailable = Config.NodeType is RaceType.circuit or RaceType.p2p or RaceType.lapknockout or RaceType.tollboothrace or RaceType.speedtraprace or RaceType.cashgrab;
    }
}