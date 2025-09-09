using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NFSMaxEd.Views
{
    public partial class AboutAuthorPage : Page
    {
        private readonly Random _random = new();
        private readonly DispatcherTimer _timer;
        public AboutAuthorPage()
        {
            InitializeComponent();
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5.5)
            };
            _timer.Tick += UpdateStats;
            _timer.Start();
        }
        private void UpdateStats(object? sender, EventArgs e)
        {
            BugsTextBlock.Text = _random.Next(200, 500).ToString();
            CoffeeTextBlock.Text = _random.Next(1000, 2000).ToString();
            CookiesTextBlock.Text = _random.Next(500, 1200).ToString();

            var phrases = new[]
            {
                "🚀Go!", "🍕Eat", "😴Nap", "🎉Fun", "💡Idea", "🛠Fix",
                "⚡Zap", "🎯Hit", "🔥Hot", "💤Zzz", "👀See", "🤖Bot",
                "🎵Jam", "☕Sip", "🍩Yum"
            };
            LinesTextBlock.Text = phrases[_random.Next(phrases.Length)];

            IdeasTextBlock.Text = _random.Next(20, 100).ToString();
            NightsTextBlock.Text = _random.Next(5, 25).ToString();

            var versionOptions = new[] { "v0.5", "v0.6", "v0.7", "vDemo" };
            VersionTextBlock.Text = versionOptions[_random.Next(versionOptions.Length)];

            var usersPhrases = new[]
            {
                "⭐1", "⭐⭐2", "⭐⭐⭐3", "🎉Hi", "👾OK", "🤩Yo", "💻Dev"
            };
            UsersTextBlock.Text = usersPhrases[_random.Next(usersPhrases.Length)];
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
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }

    }
}