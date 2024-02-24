namespace SiliconWebApp.Models.ViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign In";
    public SignInModel Form { get; set; } = new SignInModel();
}
