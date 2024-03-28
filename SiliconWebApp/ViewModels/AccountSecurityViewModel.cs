using SiliconWebApp.Models.AccountDetails;

namespace SiliconWebApp.ViewModels;

public class AccountSecurityViewModel
{
    public string Title { get; set; } = "Account Security";
    public AccountDetailsProfileInfoModel ProfileInfo { get; set; } = null!;
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = null!;
}
