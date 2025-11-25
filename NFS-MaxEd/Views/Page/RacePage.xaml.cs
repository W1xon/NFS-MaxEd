using System.Windows;
using System.Windows.Input;
using NFSMaxEd.Models;
using NFSMaxEd.Services;
using NFSMaxEd.ViewModels;

namespace NFSMaxEd.Views;

public partial class RacePage : Page, IGeneratable
{
    public RacePage()
    {
        InitializeComponent();
    }

    private void OpenMap_Click(object sender, RoutedEventArgs e)
    {
        var mapWindow = new MapWindow();
        mapWindow.Show();
    }

    public CodeInfo GenerateCode() => new CodeInfo()
    {
        Line = RaceParserFactory.CreateRaceParser(MainViewModel.Instance.Config).GenerateCode(),
        Name = MainViewModel.Instance.Config.NodeType.ToString()
    } ;
    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        MainViewModel.Instance.ResetConfigs();
        MainViewModel.Instance.UpdateVisibility();
    }


    private void ShowCashgrabInfo_OnClick(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this); 

        var infoWindow = new CashgrabInfo
        {
            Owner = window,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        infoWindow.ShowDialog();
    }


    private void ShowDragInfo_OnClick(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this); 

        var infoWindow = new DrugWindow()
        {
            Owner = window,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        infoWindow.ShowDialog();
    }
}