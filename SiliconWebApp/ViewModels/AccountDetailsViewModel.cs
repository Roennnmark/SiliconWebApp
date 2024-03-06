using Infrastructure.Entities;
using SiliconWebApp.Models.AccountDetails;

namespace SiliconWebApp.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";
    public UserEntity User { get; set; } = null!;
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel();

    public AccountDetailsAddressInfoModel AdressInfo { get; set; } = new AccountDetailsAddressInfoModel();

}
