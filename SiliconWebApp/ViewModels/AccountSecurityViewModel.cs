using Microsoft.AspNetCore.Mvc.ModelBinding;
using SiliconWebApp.Models.AccountDetails;

namespace SiliconWebApp.ViewModels;

public class AccountSecurityViewModel
{
    public string Title { get; set; } = "Account Security";
    public AccountDetailsProfileInfoModel ProfileInfo { get; set; } = null!;
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = null!;
    public SecurityViewModel SecurityInfo { get; set; } = new SecurityViewModel();
}
