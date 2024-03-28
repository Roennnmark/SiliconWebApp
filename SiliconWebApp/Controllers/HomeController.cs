﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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


}
