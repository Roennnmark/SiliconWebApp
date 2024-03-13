using Infrastructure.Entities;
using SiliconWebApp.Models.AccountDetails;

namespace SiliconWebApp.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";
    public AccountDetailsProfileInfoModel ProfileInfo { get; set; } = null!;
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = null!;

    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = null!;

}
