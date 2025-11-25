using System.Text;

namespace NFSMaxEd.Services;

public class BlacklistScriptBuilder : ScriptBuilder
{
    private readonly string _raceBin;

    public BlacklistScriptBuilder(string raceBin)
    {
        _raceBin = raceBin;
    }

    public BlacklistScriptBuilder AddRequiredBounty(int bounty)
    {
        _commands.AppendLine($"update_field gameplay {_raceBin} RequiredBounty {bounty}");
        return this;
    }

    public BlacklistScriptBuilder AddRequiredChallenges(int challenges)
    {
        _commands.AppendLine($"update_field gameplay {_raceBin} RequiredChallenges {challenges}");
        return this;
    }

    public BlacklistScriptBuilder AddRequiredRaceWon(int races)
    {
        _commands.AppendLine($"update_field gameplay {_raceBin} RequiredRacesWon {races}");
        return this;
    }

    public BlacklistScriptBuilder AddResizeField(string field, int newSize)
    {
        _commands.AppendLine($"resize_field gameplay {_raceBin} {field} {newSize}");
        return this;
    }

    public BlacklistScriptBuilder AddUpdateField(string field, int index, string value)
    {
        _commands.AppendLine($"update_field gameplay {_raceBin} {field}[{index}] {_raceBin}/{value}");
        return this;
    }
    public BlacklistScriptBuilder AddResizeMilestoneField(int newSize)
    {
        string bin = _raceBin.Replace("race_","");
        _commands.AppendLine($"resize_field gameplay milestones/{bin} Children {newSize}");
        return this;
    }

    public BlacklistScriptBuilder AddUpdateMilestoneField(int index, string value)
    {
        string bin = _raceBin.Replace("race_","");
        _commands.AppendLine($"update_field gameplay milestones/{bin} Children[{index}] {value}");
        return this;
    }
    public override string Build() => _commands.ToString();
}