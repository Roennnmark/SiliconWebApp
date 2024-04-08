using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.Models.Sections;

public class SubscriberViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Enter an valid email address")]
    [Display(Name = "Email", Prompt = "Your Email")]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email adress")]
    public string Email { get; set; } = null!;
    [Display(Name = "Daily Newsletter")]
    public bool DailyNewsletter { get; set; }
    [Display(Name = "Advertising Updates")]
    public bool AdvertisingUpdates { get; set; }
    [Display(Name = "Week in Review")]
    public bool WeekinReview { get; set; }
    [Display(Name = "Event Updates")]
    public bool EventUpdates { get; set; }
    [Display(Name = "Startups Weekly")]
    public bool StartupsWeekly { get; set; }
    [Display(Name = "Podcasts")]
    public bool Podcasts { get; set; }
}
