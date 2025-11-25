using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace NFSMaxEd.Views;

    public partial class CashgrabInfo : Window
    {
        private const string ModUrl = "https://www.nfsaddons.com/downloads/nfsmw/tools/10424/cashgrab-mode-return-mw.html"; // замени на реальный URL

        public CashgrabInfo()
        {
            InitializeComponent();
        }

        private void DownloadMod_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = ModUrl,
                UseShellExecute = true
            });
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
