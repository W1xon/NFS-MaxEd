using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class CircuitParser : BaseParser
{
    public CircuitParser(RaceConfig config) : base(config) { }

    protected override void ParseSpecificSettings()
    {
        builder.SetNumLaps(config.NumLaps);
    }
}