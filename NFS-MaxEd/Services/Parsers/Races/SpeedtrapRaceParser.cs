using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class SpeedtrapRaceParser : BaseParser
{
    public SpeedtrapRaceParser(RaceConfig config) : base(config) { }

    protected override void ParseSpecificSettings()
    {
        builder.SetChildrenEntry();
        builder.SetReputation(config.Reputation);
        builder.SetSpeedTrapList(config.Speedtraps);
        
        
        foreach (var speedtrap in config.Speedtraps)
        {
            builder.AddChildNode(EntityType.speedtrap, speedtrap.Name, new Dictionary<string, object>
            {
                {"Position", new Dictionary<string, object>
                    {
                        {"X", speedtrap.Point.PositionX},
                        {"Y", speedtrap.Point.PositionY},
                        {"Z", speedtrap.Point.PositionZ}
                    }
                },
                {"Template", ""}
            });
        }
    }
}