using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.ViewModels;

namespace SiliconWebApp.Controllers;

public class AccountController : Controller
{
    //private readonly AccountService _accountService;

    //public AccountController(AccountService accountService)
    //{
    //    _accountService = accountService;
    //}

    [Route("/")]
    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        return View(viewModel);
    }
}
