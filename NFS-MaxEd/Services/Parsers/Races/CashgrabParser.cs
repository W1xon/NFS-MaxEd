using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class CashgrabParser : BaseParser
{
    public CashgrabParser(RaceConfig config) : base(config) { }

    protected override void ParseSpecificSettings()
    {

        for (int i = 0; i < config.CashgrabCharacters.Count; i++)
            builder.UpdateOpponent(i, config.CashgrabCharacters[i].Name, true);
        builder.SetCashRewards(config.Moneybags);
        for (int i = 0; i < config.CashgrabCharacters.Count; i++)
        {
            config.CashgrabCharacters[i].Spawn = config.CashgrabOpponentSpawns[i];
            config.CashgrabCharacters[i].SkillLevel = config.SkillLevel;
        }
        
        foreach (var moneybag in config.Moneybags)
        {
            builder.AddChildNode(moneybag.SelectedType, moneybag.Name, new Dictionary<string, object>
            {
                {"Position", new Dictionary<string, object>
                    {
                        {"X", moneybag.PositionX},
                        {"Y", moneybag.PositionY},
                        {"Z", moneybag.PositionZ}
                    }
                },
                {"Template", ""}
            });
        }

        foreach (var character in config.CashgrabCharacters)
        {
            builder.AddCashgrabCharacter(EntityType.character.ToString(), character.Name,  new Dictionary<string, object>
            {
                {"CannedPath", GetCannedPath()},
                {"Children", character.Spawn.Name},
                {"ForceStartPosition", character.Spawn.Name},
                {"SkillLevel", character.SkillLevel},
                {"Template", ""}
            });
        }
        foreach (var spawn in config.CashgrabOpponentSpawns)
        {
            builder.AddChildNode(EntityType.carmarker, spawn.Name, new Dictionary<string, object>
            {
                {"Position", new Dictionary<string, object>
                    {
                        {"X", spawn.PositionX},
                        {"Y", spawn.PositionY},
                        {"Z", spawn.PositionZ}
                    }
                },
                {"Rotation", spawn.Rotation},
                {"Template", ""}
            });
        }
    }

    private List<string> GetCannedPath()
    {
        return config.Moneybags.Select(m => m.Name).ToList();
    }


}