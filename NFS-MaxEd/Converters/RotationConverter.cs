namespace NFSMaxEd.Converters;

public class RotationConverter
{
    public static float HexToDegrees(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            return 0f;

        if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            hex = hex[2..];

        if (!uint.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out uint value))
            throw new FormatException($"Invalid hex rotation value: {hex}");

        double angle = (value / 65536.0) * 360.0;

        return (float)Math.Round(angle, 4, MidpointRounding.AwayFromZero);
    }
}