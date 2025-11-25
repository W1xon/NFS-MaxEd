using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using NFSMaxEd.Services;

namespace NFSMaxEd.Views;

public partial class WelcomeWindow : Window
{
    public WelcomeWindow()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        if (DontShowAgainCheckBox.IsChecked == true)
        {
            FirstRunService.MarkAsRun();
        }
            
        Close();
    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
        e.Handled = true;
    }
}