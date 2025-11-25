using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using NFSMaxEd.Models;
using NFSMaxEd.Services;
using NFSMaxEd.ViewModels;

namespace NFSMaxEd.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private MainViewModel MainViewModel { get; }

    public MainWindow()
    {
        InitializeComponent();
        
        if (FirstRunService.IsFirstRun())
        {
            ShowWelcomeWindow();
        }

        
        MainViewModel = MainViewModel.Instance;
        DataContext = MainViewModel;

        MainFrame.Navigated += MainFrame_Navigated;

        MainFrame.Content = new RacePage();
    }

    private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
        if (e.Content is Page page)
        {
            UpdateWindowControls(page);
        }
    }

    private void UpdateWindowControls(Page page)
    {
        page.DataContext = MainViewModel;
    }


    private void Minimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void Maximize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void DragWindow(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            DragMove();
    }


    private void OnRacesClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new RacePage());
    }

    private void OnMilestonesClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new MilestonesPage());
    }

    private void OnBlacklistClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new BlackListPage());
    }

    private void OnAboutAuthorClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new AboutAuthorPage());
    }

    
    private void OnGenerateClick(object sender, RoutedEventArgs e)
    {
        if (MainFrame.Content is not IGeneratable page)
        {
            MessageBox.Show("Эта страница не поддерживает генерацию скрипта.",
                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        CodeInfo codeInfo = page.GenerateCode();
        FileService.SaveNFSMS(codeInfo.Line, codeInfo.Name);
    }

    private void TogglePanel_Click(object sender, RoutedEventArgs e)
    {
        bool isCollapsed = LeftPanel.Visibility == Visibility.Collapsed;

        LeftPanel.Visibility = isCollapsed ? Visibility.Visible : Visibility.Collapsed;

        TogglePanelButton.ToolTip = isCollapsed ? "Hide Panel" : "Show Panel";
    }
    
    private void ShowWelcomeWindow()
    {
        var welcomeWindow = new WelcomeWindow();
        
        welcomeWindow.ShowDialog();
    }
}