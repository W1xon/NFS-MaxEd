using System.Collections.ObjectModel;

namespace NFSMaxEd.Models;

public class MilestoneConfig : ObservableObject
{
    public MilestoneConfig()
    {
        MilestoneTypes.Add("milestone_cops_damaged");
        MilestoneTypes.Add("milestone_cops_destroyed");
        MilestoneTypes.Add("milestone_cost_to_state");
        MilestoneTypes.Add("milestone_pursuit_evasion_time");
        MilestoneTypes.Add("milestone_pursuit_length");
        MilestoneTypes.Add("milestone_roadblocks_dodged");
        MilestoneTypes.Add("milestone_tire_spikes_dodged");
        MilestoneTypes.Add("milestone_total_infractions");

        if (MilestoneTypes.Count > 0)
            MilestoneType = MilestoneTypes[0];

        SpawnPoints.Add("milestones/bin_08/taggedcarmarker1");
        SpawnPoints.Add("milestones/bin_12/taggedcarmarker1");
        SpawnPoints.Add("milestones/bin_15/taggedcarmarker1");

        if (SpawnPoints.Count > 0)
            SelectedSpawnPoint = SpawnPoints[0];
        
        for (int i = 1; i <= 15; i++)
        {
            BinIndices.Add($"bin_{i:00}");
        }

        if (BinIndices.Count > 0)
            SelectedBinIndex = BinIndices[0];
    }

    public ObservableCollection<string> MilestoneTypes { get; } = new();

    private string _milestoneType;
    public string MilestoneType
    {
        get => _milestoneType;
        set => Set(ref _milestoneType, value);
    }

    public ObservableCollection<string> SpawnPoints { get; } = new();

    private string _selectedSpawnPoint;
    public string SelectedSpawnPoint
    {
        get => _selectedSpawnPoint;
        set => Set(ref _selectedSpawnPoint, value);
    }
    public ObservableCollection<string> BinIndices { get; } = new();

    private string _selectedBinIndex;
    public string SelectedBinIndex
    {
        get => _selectedBinIndex;
        set => Set(ref _selectedBinIndex, value);
    }

    private int _bounty;
    public int Bounty
    {
        get => _bounty;
        set => Set(ref _bounty, value);
    }

    private int _goalAddPrevBest;
    public int GoalAddPrevBest
    {
        get => _goalAddPrevBest;
        set => Set(ref _goalAddPrevBest, value);
    }

    private int _goalEasy;
    public int GoalEasy
    {
        get => _goalEasy;
        set => Set(ref _goalEasy, value);
    }

    private int _goalHard;
    public int GoalHard
    {
        get => _goalHard;
        set => Set(ref _goalHard, value);
    }


}