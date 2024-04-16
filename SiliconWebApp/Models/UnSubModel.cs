using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.Models;

public class UnSubModel
{
    [Display(Name = "Enter your e-mail to unsubscribe", Prompt = "Email address")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email adress")]
    public string Email { get; set; } = null!;
}
