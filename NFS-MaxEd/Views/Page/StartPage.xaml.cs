using System.Windows;
using System.Windows.Controls;

namespace NFSMaxEd.Views;

public partial class StartPage : Page
{
    public StartPage()
    {
        InitializeComponent();
        DataContext = (Application.Current.MainWindow as MainWindow)?.DataContext;
    }

    private void OnRacesClick(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService.Navigate(new RacePage());
    }

    private void OnMilestonesClick(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService.Navigate(new MilestonesPage());
    }

    private void OnBlacklistClick(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService.Navigate(new BlackListPage());
    }
    private void OnAboutAuthorClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new AboutAuthorPage());
    }

}