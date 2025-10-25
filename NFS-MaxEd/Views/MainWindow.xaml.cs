using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        InitializeComponent(); // Инициализируем ViewModel
        MainViewModel = MainViewModel.Instance;
        DataContext = MainViewModel;

        // Подписываемся на событие изменения контента Frame
        MainFrame.Navigated += MainFrame_Navigated;

        // Устанавливаем начальную страницу
        MainFrame.Content = new RacePage();
    }

    // Обработчик события навигации Frame
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
        FileService.SaveDemoScript();
    }

    private void TogglePanel_Click(object sender, RoutedEventArgs e)
    {
        bool isCollapsed = LeftPanel.Visibility == Visibility.Collapsed;

        LeftPanel.Visibility = isCollapsed ? Visibility.Visible : Visibility.Collapsed;

        TogglePanelButton.ToolTip = isCollapsed ? "Hide Panel" : "Show Panel";
    }
}