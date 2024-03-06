using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.Models.Views;

namespace SiliconWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
        ViewData["Title"] = viewModel.Title;

        return View(viewModel);
    }

    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();


}
