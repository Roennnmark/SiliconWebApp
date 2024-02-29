using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.ViewModels;

namespace SiliconWebApp.Controllers;

public class AuthController(UserService userService) : Controller
{
    private readonly UserService _userService = userService;

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp() => View(new SignUpViewModel());

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
            {
                return RedirectToAction("SignIn", "Auth");
            }
            else
            {
                return View(viewModel);
            }
        }
        else
        {
            return View(viewModel);
        }
        
    }

    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn() => View(new SignInViewModel());
    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var result = await _userService.SignInUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                return RedirectToAction("Details", "Account");
        }

        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);
    }
}
