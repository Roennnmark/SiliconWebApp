using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.Models;
using SiliconWebApp.Models.Sections;
using SiliconWebApp.Models.Views;
using System.Net.Http;
using System.Text;
using static System.Net.WebRequestMethods;

namespace SiliconWebApp.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
        ViewData["Title"] = viewModel.Title;

        return View(viewModel);
    }
    [HttpGet]
    public IActionResult Subscribe()
    {
        var viewModel = new SubscriberViewModel();
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscriberViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                using var http = new HttpClient();

                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                var response = await http.PostAsync("https://localhost:7019/api/subscribers", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Status"] = "Success";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["Status"] = "AlreadyExists";
                }
            }
            catch
            {
                TempData["Status"] = "ConnectionFailed";
            }
        }
        else
        {
            TempData["Status"] = "Invalid";
        }

        return RedirectToAction("Index");
    }

    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();

    [Route("/contact")]
    public IActionResult Contact()
    {
        return View();
    }
    [HttpGet]
    [Route("/unsubscribe")]
    public IActionResult Unsub()
    {
        var viewModel = new UnSubViewModel();
        viewModel.UnSubModel = new UnSubModel(); // Skapa en instans av UnSubModel för att undvika nullreferensfel
        return View(viewModel);
    }
    [HttpPost]
    [Route("/unsubscribe")]
    public async Task<IActionResult> Unsub(UnSubViewModel unSub)
    {
        if (ModelState.IsValid)
        {
            try
            {
                

                if (unSub != null)
                {
                    using var http = new HttpClient();
                    var UnSubscribe = new UnSubModel
                    {
                        Email = unSub.UnSubModel!.Email,
                    };

                    var response = await http.DeleteAsync($"https://localhost:7019/api/subscribers/{UnSubscribe.Email}");

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Status"] = "Success";
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        TempData["Status"] = "AlreadyExists";
                    }
                }

            }
            catch
            {
                TempData["Status"] = "ConnectionFailed";
            }
        }
        else
        {
            TempData["Status"] = "Invalid";
        }

        return RedirectToAction("Index");
    }
}
