using NFSMaxEd.Models;
using NFSMaxEd.Services;
using NFSMaxEd.ViewModels;

namespace NFSMaxEd.Views;

public partial class BlackListPage : Page, IGeneratable
{
    public BlackListPage() => InitializeComponent();

    public CodeInfo GenerateCode() => new()
    {
        Line = new BlacklistParser(MainViewModel.Instance.Blacklist, new BlacklistStore()).GenerateCode(),
        Name = nameof(BlackListPage)
    };
}