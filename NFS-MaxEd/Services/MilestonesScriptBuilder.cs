namespace NFSMaxEd.Services;

public class MilestonesScriptBuilder : ScriptBuilder
{
    private readonly string _raceBin;
    private int _binIndex;
    private string _collectionName;

    private readonly List<string> _addCommands = new();
    private readonly List<string> _updateCommands = new();

    public MilestonesScriptBuilder(string raceBin)
    {
        _raceBin = raceBin;
        _binIndex = Convert.ToInt32(raceBin.Split("_")[1]);
    }

    public MilestonesScriptBuilder SetCollectionName(string milestoneType)
    {
        _collectionName = $"challenge_{_binIndex}_{milestoneType}";
        return this;
    }

    public MilestonesScriptBuilder AddNode(string milestoneType)
    {
        _addCommands.Add($"add_node gameplay {milestoneType} milestones/{_raceBin}/{_collectionName}");
        return this;
    }

    public MilestonesScriptBuilder AddBinIndex()
    {
        _addCommands.Add($"add_field gameplay milestones/{_raceBin}/{_collectionName} BinIndex");
        _updateCommands.Add($"update_field gameplay milestones/{_raceBin}/{_collectionName} BinIndex {_binIndex}");
        return this;
    }

    public MilestonesScriptBuilder AddGoalAddPrevBest(int value)
    {
        _addCommands.Add($"add_field gameplay milestones/{_raceBin}/{_collectionName} GoalAddPrevBest");
        _updateCommands.Add($"update_field gameplay milestones/{_raceBin}/{_collectionName} GoalAddPrevBest {value}");
        return this;
    }

    public MilestonesScriptBuilder AddGoalEasy(int value)
    {
        _addCommands.Add($"add_field gameplay milestones/{_raceBin}/{_collectionName} GoalEasy");
        _updateCommands.Add($"update_field gameplay milestones/{_raceBin}/{_collectionName} GoalEasy {value}");
        return this;
    }

    public MilestonesScriptBuilder AddGoalHard(int value)
    {
        _addCommands.Add($"add_field gameplay milestones/{_raceBin}/{_collectionName} GoalHard");
        _updateCommands.Add($"update_field gameplay milestones/{_raceBin}/{_collectionName} GoalHard {value}");
        return this;
    }

    public MilestonesScriptBuilder AddTemplate()
    {
        _addCommands.Add($"add_field gameplay milestones/{_raceBin}/{_collectionName} Template");
        return this;
    }

    public MilestonesScriptBuilder AddSpawnPoint(string spawnPoint)
    {
        _addCommands.Add($"add_field gameplay milestones/{_raceBin}/{_collectionName} SpawnPoint");
        _updateCommands.Add($"update_field gameplay milestones/{_raceBin}/{_collectionName} SpawnPoint {spawnPoint}");
        return this;
    }

    public override string Build()
    {
        foreach (var cmd in _addCommands)
            _commands.AppendLine(cmd);
        foreach (var cmd in _updateCommands)
            _commands.AppendLine(cmd);

        return _commands.ToString();
    }
}
