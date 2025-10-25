using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace NFSMaxEd.Views
{
    /// <summary>
    /// About the Author page with social links and donation options
    /// </summary>
    public partial class AboutAuthorPage : Page
    {
        public AboutAuthorPage()
        {
            InitializeComponent();
        }
        private void SocialButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string url)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch
                {
                    MessageBox.Show("Не удалось открыть ссылку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.donationalerts.com/r/w1xon",
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("Не удалось открыть ссылку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

    }
}