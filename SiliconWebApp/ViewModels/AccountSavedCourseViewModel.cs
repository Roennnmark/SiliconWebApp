using SiliconWebApp.Models.AccountDetails;

namespace SiliconWebApp.ViewModels;

public class AccountSavedCourseViewModel
{
    public string Title { get; set; } = "Saved Courses";
    public AccountDetailsProfileInfoModel ProfileInfo { get; set; } = null!;
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = null!;
}
