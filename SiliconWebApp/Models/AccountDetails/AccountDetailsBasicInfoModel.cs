using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.Models.AccountDetails;

public class AccountDetailsBasicInfoModel
{
    public string UserId { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "First Name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last Name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email adress")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your phone")]
    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }

    [Display(Name = "Bio", Prompt = "Add a short bio...")]
    [DataType(DataType.MultilineText)]
    public string? Biography { get; set; }
}
