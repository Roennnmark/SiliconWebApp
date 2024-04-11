using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.ViewModels;

public class SecurityViewModel
{
    [Display(Name = "Current Password", Prompt = "********")]
    [Required(ErrorMessage = "Current password is required")]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password")]
    public string CurrentPassword { get; set; } = null!;

    [Display(Name = "Password", Prompt = "********")]
    [Required(ErrorMessage = "New password is required")]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password")]
    public string NewPassword { get; set; } = null!;

    [Display(Name = "Password", Prompt = "********")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(NewPassword), ErrorMessage = "Password does not match")]
    public string ConfirmNewPassword { get; set; } = null!;

    [Display(Name = "Delete account")]
    public bool DeleteAccountConfirmed { get; set; }
}
