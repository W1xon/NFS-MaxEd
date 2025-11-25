using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class RaceParserFactory
{
    public static BaseParser CreateRaceParser(RaceConfig config)
    {
        return config.NodeType switch
        {
            RaceType.circuit => new CircuitParser(config),
            RaceType.p2p => new P2PParser(config),
            RaceType.lapknockout => new LapknockoutParser(config),
            RaceType.tollboothrace => new TollboothRaceParser(config),
            RaceType.speedtraprace => new SpeedtrapRaceParser(config),
            RaceType.cashgrab => new CashgrabParser(config),
            RaceType.drag => new DragParser(config),
            _ => throw new ArgumentException($"Unsupported NodeType: {config.NodeType}")
        };
    }
}
