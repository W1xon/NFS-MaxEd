using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class LapknockoutParser : BaseParser
{
    public LapknockoutParser(RaceConfig config) : base(config) { }

    protected override void ParseSpecificSettings()
    {
        builder.SetNumLaps(config.NumLaps);
    }
}