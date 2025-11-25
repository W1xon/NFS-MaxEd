using System.Windows;
using NFSMaxEd.Services;
using NFSMaxEd.ViewModels;

namespace NFSMaxEd.Views;

public partial class MilestonesPage : Page, IGeneratable
{
    public MilestonesPage()
    {
        InitializeComponent();
    }

    public CodeInfo GenerateCode() => new CodeInfo()
    {
        Line = new MilestoneParser(MainViewModel.Instance.MilestoneConfig).GenerateCode(),
        Name = "MilestonesPage"
    } ;
}