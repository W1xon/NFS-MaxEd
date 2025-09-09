using System.Windows;
using System.Windows.Controls;
using NFSMaxEd.Models;
using NFSMaxEd.Services;
using NFSMaxEd.ViewModels;

namespace NFSMaxEd.Views;

public partial class BlackListPage : Page
{
    public BlackListPage()
    {
        InitializeComponent();
    } 
    private void OnGenerateClick(object sender, RoutedEventArgs e)
    {
        FileService.SaveDemoScript();
    }

    private void GoToStartPage_Click(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new StartPage());
    }
}