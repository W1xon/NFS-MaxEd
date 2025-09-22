using System.Windows;
using System.Windows.Controls;
namespace NFSMaxEd.Views;

public partial class MilestonesPage : Page
{
    public MilestonesPage()
    {
        InitializeComponent();
    }
    private void OnGenerateClick(object sender, RoutedEventArgs e)
    {
    }

    private void GoToStartPage_Click(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new StartPage());
    }
}