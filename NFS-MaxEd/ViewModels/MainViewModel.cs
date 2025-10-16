﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NFSMaxEd.Models;
using Barrier = NFSMaxEd.Models.Barrier;

namespace NFSMaxEd.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly RaceConfig _config = new();
    public RaceConfig Config => _config;
    public BlacklistConfig Blacklist { get; } = new();
    public MilestoneConfig MilestoneConfig { get; } = new();

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
        InitializeConfigCommands();
        InitializeBlacklistCommands();
        _config.PropertyChanged += Config_PropertyChanged;
        UpdateVisibility();
    }

    #region Config Commands Initialization

    private void InitializeConfigCommands()
    {
        InitializeBarrierCommands();
        InitializeOpponentCommands();
        InitializeCheckpointCommands();
        InitializeTimeBonusCheckpoint();
        InitializeShortcutCommands();
        InitializeSpeedtrapCommands();
        InitializeCharacterDrugCommands();
    }

    private void InitializeBarrierCommands()
    {
        Config.AddBarrierCommand = new RelayCommand(_ => Config.Barriers.Add(new Barrier()));
        Config.RemoveBarrierCommand = new RelayCommand(p =>
        {
            if (p is Barrier b) Config.Barriers.Remove(b);
        });
    }

    private void InitializeOpponentCommands()
    {
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
    }

    private void InitializeCheckpointCommands()
    {
        Config.AddCheckpointCommand = CreateAddCommand(Config.Checkpoints,
            () => new CheckpointEntity(EntityType.checkpoint), EntityType.checkpoint);
        Config.RemoveCheckpointCommand = new RelayCommand(p =>
        {
            if (p is CheckpointEntity item)
            {
                Config.Checkpoints.Remove(item);
                if(!item.Name.Contains("/"))
                {
                     UpdateNames(Config.Checkpoints, item.EntityType.ToString());
                }
                else
                {
                    UpdateNames(Config.Checkpoints, $"/{item.EntityType.ToString()}");
                }
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
            
            UpdateNames(Config.CharacterDrugs, "character");
            UpdateNames(Config.TrafficSpawnTriggers, "trafficspawntrigger");
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
                
                UpdateNames(Config.CharacterDrugs, "character");
                UpdateNames(Config.TrafficSpawnTriggers, "trafficspawntrigger");
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
    }

    
    private RelayCommand CreateAddCommand<T>(IList<T> collection, Func<T> factory, EntityType baseName = default) where T : BaseEntity
    {
        return new RelayCommand(_ =>
        {
            var item = factory();
            collection.Add(item);
            if (baseName != default) UpdateNames(collection, baseName.ToString());
        });
    }

    private RelayCommand CreateRemoveCommand<T>(IList<T> collection, EntityType baseName = default) where T : BaseEntity
    {
        return new RelayCommand(p =>
        {
            if (p is T item)
            {
                collection.Remove(item);
                if (baseName != default) UpdateNames(collection, baseName.ToString());
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
                UpdateNames(collection, baseName);
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
                    UpdateNames(collection, baseName);
            }
        });
    }

    private RelayCommand CreateAddCommand(IList<StringWrapper> collection)
    {
        return new RelayCommand(_ => collection.Add(string.Empty));
    }

    private RelayCommand CreateRemoveCommand(IList<StringWrapper> collection) 
    {
        return new RelayCommand(p =>
        {
            if (p is string s) collection.Remove(s);
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
        Config.IsCircuitOrKnockout = Config.NodeType is RaceType.circuit or RaceType.lapknockout;
        Config.IsTollbooth = Config.NodeType == RaceType.tollboothrace;
        Config.IsSpeedtrap = Config.NodeType == RaceType.speedtraprace;
        Config.IsDrag = Config.NodeType == RaceType.drag;
        Config.IsShortcutAvailable = Config.NodeType is RaceType.circuit or RaceType.p2p or RaceType.lapknockout or RaceType.tollboothrace or RaceType.speedtraprace;
    }
    private void UpdateNames<T>(IList<T> list, string baseName) where T : BaseEntity
    {
        var existingNumbers = list
            .Where(l => !string.IsNullOrWhiteSpace(l.Name) && l.Name.StartsWith(baseName))
            .Select(l => 
            {
                var digits = new string(l.Name.Skip(baseName.Length).ToArray());
                return int.TryParse(digits, out int n) ? n : 0;
            })
            .ToHashSet();

        int counter = 1;

        foreach (var item in list)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                while (existingNumbers.Contains(counter))
                    counter++;

                item.Name = $"{baseName}{counter}";
                existingNumbers.Add(counter);
            }
        }

        var sorted = list.OrderBy(item => GetIndexFromName(item.Name)).ToList();

        for (int i = 0; i < sorted.Count; i++)
        {
            list[i] = sorted[i];
        }


    }
    private int GetIndexFromName(string name)
    {
        var digits = new string(name.Reverse().TakeWhile(char.IsDigit).Reverse().ToArray());
        return int.TryParse(digits, out int val) ? val : -1;
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}