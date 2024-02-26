using SiliconWebApp.Models.AccountDetails;

namespace SiliconWebApp.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel()
    {
        ProfileImage = "images/avatar.svg",
        FirstName = "Mathias",
        LastName = "Rönnmark",
        Email = "mathias@hotmail.com"
    };
    public AccountDetailsAddressInfoModel AdressInfo { get; set; } = new AccountDetailsAddressInfoModel();

}
