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

    [Route("/account")]
    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        //viewModel.BasicInfo = _accountService.GetBasicInfo();
        //viewModel.AdressInfo = _accountService.GetAdressInfo();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult BasicInfo(AccountDetailsViewModel viewModel)
    {
        //_accountService.SaveBasicInfo(viewModel.BasicInfo);
        return RedirectToAction(nameof(Details));
    }

    [HttpPost]
    public IActionResult AdressInfo(AccountDetailsViewModel viewModel)
    {
        //_accountService.SaveAddressInfo(viewModel.AdressInfo);
        return RedirectToAction(nameof(Details));
    }
}
