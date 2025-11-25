using System.IO;
using Microsoft.Win32;
using NFSMaxEd.ViewModels;

namespace NFSMaxEd.Services;

public class FileService
{
    public static void SaveNFSMS(string code, string articleName = "")
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "NFS Files (*.nfsms)|*.nfsms",
            FileName = $"MaxEd-race_{articleName}.nfsms",
            Title = "Сохранить код"
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            File.WriteAllText(saveFileDialog.FileName, code);
        }
    }
}