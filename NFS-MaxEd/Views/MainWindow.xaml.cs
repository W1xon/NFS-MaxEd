using System.Windows.Controls;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using NFSMaxEd.Services;
using NFSMaxEd.ViewModels;

namespace NFSMaxEd.Views;

public partial class MainWindow : Window
{
    private MainViewModel MainViewModel { get; }
    
    public MainWindow()
    {
        InitializeComponent(); 
        MainViewModel = MainViewModel.Instance;
        DataContext = MainViewModel;
        
        MainFrame.Navigated += MainFrame_Navigated;
        
        MainFrame.Content = new StartPage();
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
        UnsubscribeFromPageEvents();
        
        page.DataContext = MainViewModel;
        
        if (page is RacePage racePage)
        {
            racePage.TitleBarMouseLeftButtonDown += DragWindow;
        }
    }

    private void UnsubscribeFromPageEvents()
    {
        if (MainFrame.Content is RacePage previousRacePage)
        {
            previousRacePage.TitleBarMouseLeftButtonDown -= DragWindow;
        }
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

    protected override void OnClosed(EventArgs e)
    {
        UnsubscribeFromPageEvents();
        base.OnClosed(e);
    }
}