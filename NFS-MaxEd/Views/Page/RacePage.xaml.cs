using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NFSMaxEd.Services;
using NFSMaxEd.ViewModels;

namespace NFSMaxEd.Views;

public partial class RacePage : Page
{
    public event MouseButtonEventHandler TitleBarMouseLeftButtonDown;

    public RacePage()
    {
        InitializeComponent();
    }

    private void OpenMap_Click(object sender, RoutedEventArgs e)
    {
        var mapWindow = new MapWindow();
        mapWindow.ShowDialog();
    }

    private void OnGenerateClick(object sender, RoutedEventArgs e)
    {;
        FileService.SaveDemoScript();
    }

    private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        TitleBarMouseLeftButtonDown?.Invoke(this, e);
    }
    private void GoToStartPage_Click(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new StartPage());
    }

}