using SiliconWebApp.Models.Sections;

namespace SiliconWebApp.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Ultimate Task Management Assistant";
    public ShowcaseViewModel Showcase { get; set; } = new ShowcaseViewModel
    {
        Id = "overview",
        ShowcaseImage = new() { ImageUrl = "/images/showcase-taskmaster.svg", AltText = "Task Management Assistant" },
        Title = "Ultimate Task Management Assistant",
        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
        Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get started for free" },
        BrandsText = "Largest companies use our tool to work efficiently",
        Brands =
        [
            new() { ImageUrl = "/images/logo-1.svg", AltText = "Brand Name 1" },
            new() { ImageUrl = "/images/logo-2.svg", AltText = "Brand Name 2" },
            new() { ImageUrl = "/images/logo-3.svg", AltText = "Brand Name 3" },
            new() { ImageUrl = "/images/logo-4.svg", AltText = "Brand Name 4" },
        ],
    };
}
