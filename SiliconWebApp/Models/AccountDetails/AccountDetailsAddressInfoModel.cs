using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.Models.AccountDetails;

public class AccountDetailsAddressInfoModel
{
    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    public string Addressline_1 { get; set; } = null!;

    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    public string Adressline_2 { get; set; } = null!;

    [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
    [Required(ErrorMessage = "Postal code is required")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = null!;
}
