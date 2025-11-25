using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NFSMaxEd.Converters;

public class MultiBooleanToVisibilityConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.OfType<bool>().Any(v => v))
            return Visibility.Visible;
        return Visibility.Collapsed;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
