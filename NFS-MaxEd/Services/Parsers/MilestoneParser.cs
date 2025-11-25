using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class MilestoneParser
{
    
    private readonly MilestoneConfig _milestoneConfig;
    private readonly MilestonesScriptBuilder _builder;

    public MilestoneParser(MilestoneConfig milestoneConfig)
    {
        _milestoneConfig = milestoneConfig;
        _builder = new MilestonesScriptBuilder(milestoneConfig.SelectedBinIndex);
    }
    public string GenerateCode()
    {
        _builder.SetCollectionName(_milestoneConfig.MilestoneType)
            .AddNode(_milestoneConfig.MilestoneType)
            .AddBinIndex()
            .AddGoalEasy(_milestoneConfig.GoalEasy)
            .AddGoalAddPrevBest(_milestoneConfig.GoalAddPrevBest)
            .AddGoalHard(_milestoneConfig.GoalHard)
            .AddSpawnPoint(_milestoneConfig.SelectedSpawnPoint)
            .AddTemplate();
        return _builder.Build();
    }
}