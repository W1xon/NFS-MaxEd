using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class TollboothRaceParser : BaseParser
{
    public TollboothRaceParser(RaceConfig config) : base(config) { }

    protected override void ParseSpecificSettings()
    {
        builder.SetChildrenEntry();
        builder.SetTimeLimit(config.TimeLimit);
        var tbc = config.Checkpoints.Where(c => c.Name.Contains('/'));
        foreach (var timeBonusCheckpoint in tbc)
        {
            builder.AddChildNode(EntityType.timebonuscheckpoint, timeBonusCheckpoint.Name.Replace("/", "time_bonus_"), new Dictionary<string, object>
            {
                {"Position", new Dictionary<string, object>
                    {
                        {"X", timeBonusCheckpoint.PositionX},
                        {"Y", timeBonusCheckpoint.PositionY},
                        {"Z", timeBonusCheckpoint.PositionZ}
                    }
                },
                {"Rotation", timeBonusCheckpoint.Rotation},
                {"TimeBonus", timeBonusCheckpoint.TimeBonus},
                {"Template", ""}
            });
        }
    }
}