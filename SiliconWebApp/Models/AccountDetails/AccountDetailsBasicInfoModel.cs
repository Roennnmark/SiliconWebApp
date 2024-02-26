using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.Models.AccountDetails;

public class AccountDetailsBasicInfoModel
{
    [DataType(DataType.ImageUrl)]
    public string? ProfileImage { get; set; }

    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email adress")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your phone", Order = 3)]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; } = null!;

    [Display(Name = "Bio", Prompt = "Add a short bio...", Order = 4)]
    [DataType(DataType.MultilineText)]
    public string? Biography { get; set; }
}
