using Microsoft.Win32;
using System;
using System.IO;
using System.Text;

namespace NFSMaxEd.Services
{
    public static class FileService
    {
        public static void SaveDemoScript()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                DefaultExt = "txt",
                FileName = "demo_script.txt",
                Title = "Save Demo Script"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                string version = "MaxEd Demo v0.5";

                StringBuilder sb = new();
                sb.AppendLine("========================================");
                sb.AppendLine($"          {version}");
                sb.AppendLine("----------------------------------------");
                sb.AppendLine(" In the demo version, code generation is disabled.");
                sb.AppendLine(" Please check out the UI/UX and wait for the full release!");
                sb.AppendLine("----------------------------------------");
                sb.AppendLine($" Saved on: {date}");
                sb.AppendLine("========================================");
                sb.AppendLine("  Telegram: https://t.me/CoderW0rker"); 
                sb.AppendLine("========================================");

                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }
        }
    }
}
