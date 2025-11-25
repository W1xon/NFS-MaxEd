using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class DragParser : BaseParser
{
    public DragParser(RaceConfig config) : base(config) { }

    protected override void ParseSpecificSettings()
    {
        builder.SetChildrenEntry();
        builder.SetReputation(config.Reputation);

        for (int i = 0; i < config.CharacterDrugs.Count; i++)
            AddCharacterToBuilder(config.CharacterDrugs[i], config.TrafficSpawnTriggers[i]);

        foreach (var trigger in config.TrafficSpawnTriggers)
            AddTrafficSpawnTriggerToBuilder(trigger);


        if (config.StartMarker != null)
            AddMarker("start_marker", config.StartMarker);

        if (config.FinishMarker != null)
            AddMarker("finish_marker", config.FinishMarker);

        builder.SetRandomSpawnTriggers(config.TrafficSpawnTriggers);
    }
    private void AddCharacterToBuilder(CharacterDrug character, TrafficSpawnTrigger trigger)
    {
        builder.AddCharacter(EntityType.character.ToString(), trigger.Name, character.Name,
            new Dictionary<string, object>
            {
                {"CarType", character.SelectedCarType},
                {"fecompressionstoggle", character.Faceompressionstoggle},
                {"Template", character.Template}
            });
    }

    private void AddTrafficSpawnTriggerToBuilder(TrafficSpawnTrigger trigger)
    {
        builder.AddChildNode(EntityType.trafficspawntrigger, trigger.Name, new Dictionary<string, object>
        {
            {"Position", new Dictionary<string, object>{{"X", trigger.PositionX},{"Y", trigger.PositionY},{"Z", trigger.PositionZ}}},
            {"Rotation", trigger.Rotation},
            {"TrafficCharacter", trigger.TrafficCharacter},
            {"Children", trigger.TrafficCharacter},
            {"InitialSpeed", config.InitialSpeed},
            {"Radius", trigger.Radius},
            {"TargetMarker", trigger.TargetMarker},
            {"Template", ""}
        });
    }
    private void AddMarker(string name, PointEntity marker)
    {
        builder.AddChildNode(EntityType.marker, name, GetTransformDict(marker.PositionX, marker.PositionY, marker.PositionZ, marker.Rotation), true);
    }

}