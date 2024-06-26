﻿using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositiories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SiliconWebApp.Models;
using SiliconWebApp.Models.AccountDetails;
using SiliconWebApp.ViewModels;
using System.Numerics;

namespace SiliconWebApp.Controllers;

[Authorize]
public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressService addressService, AddressRepository addressRepository, ProfileImageService profileImage) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly AddressService _addressService = addressService;
    private readonly AddressRepository _addressRepository = addressRepository;
    private readonly ProfileImageService _profileImage = profileImage;

    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Auth");

        var viewModel = new AccountDetailsViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };

        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }

    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfo != null)
        {
            if (viewModel.BasicInfo.FirstName != null && viewModel.BasicInfo.LastName != null && viewModel.BasicInfo.Email != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfo.FirstName;
                    user.LastName = viewModel.BasicInfo.LastName;
                    user.Email = viewModel.BasicInfo.Email;
                    user.PhoneNumber = viewModel.BasicInfo.Phone;
                    user.BioGraphy = viewModel.BasicInfo.Biography;
                    user.UserName = viewModel.BasicInfo.Email;

                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                        ViewData["ErrorMessage"] = "Something went wrong! Unable to save data.";
                    }
                }
            }
        }

        if (viewModel.AddressInfo != null)
        {
            if (viewModel.AddressInfo.Addressline_1 != null && viewModel.AddressInfo.PostalCode != null && viewModel.AddressInfo.City != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var addressResult = await _addressService.GetAddressAsync(user.Id);
                    if (addressResult != null)
                    {
                        addressResult.AddressLine_1 = viewModel.AddressInfo.Addressline_1;
                        addressResult.AddressLine_2 = viewModel.AddressInfo.Addressline_2!;
                        addressResult.PostalCode = viewModel.AddressInfo.PostalCode;
                        addressResult.City = viewModel.AddressInfo.City;

                        var result = await _addressService.UpdateAddressAsync(addressResult);
                        if (!result)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save address data.");
                            ViewData["ErrorMessage"] = "Something went wrong! Unable to save address data.";
                        }
                    }
                    else
                    {
                        addressResult = new AddressEntity
                        {
                            UserId = user.Id,
                            AddressLine_1 = viewModel.AddressInfo.Addressline_1,
                            AddressLine_2 = viewModel.AddressInfo.Addressline_2,
                            PostalCode = viewModel.AddressInfo.PostalCode,
                            City = viewModel.AddressInfo.City,
                        };

                        var result = await _addressService.CreateAddressAsync(addressResult);
                        if (!result)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save address data.");
                            ViewData["ErrorMessage"] = "Something went wrong! Unable to save address data.";
                        }
                    }
                }
            }
        }

        viewModel.ProfileInfo = await PopulateProfileInfoAsync();
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }

    private async Task<AccountDetailsProfileInfoModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsProfileInfoModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
        };
    }

    private async Task<AccountDetailsBasicInfoModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsBasicInfoModel
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber,
            Biography = user.BioGraphy
        };
    }

    private async Task<AccountDetailsAddressInfoModel> PopulateAddressInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var addressResult = await _addressService.GetAddressAsync(user.Id);

            if (addressResult != null)
            {
                return new AccountDetailsAddressInfoModel
                {
                    Addressline_1 = addressResult.AddressLine_1,
                    Addressline_2 = addressResult.AddressLine_2,
                    PostalCode = addressResult.PostalCode,
                    City = addressResult.City
                };
            }

        }
        return new AccountDetailsAddressInfoModel();
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        var result = await _profileImage.UploadUserProfileImageAsync(User, file);

        return RedirectToAction("Details", "Account");
    }

    [HttpGet]
    [Route("/account/security")]
    public async Task<IActionResult> Security()
    {
        var viewModel = new AccountSecurityViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
        }

        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(AccountSecurityViewModel viewModel)
    {
        ModelState.Remove("ProfileInfo");
        ModelState.Remove("BasicInfo");

        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, viewModel.SecurityInfo.CurrentPassword, viewModel.SecurityInfo.NewPassword);

                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
        }

        return RedirectToAction("Security", "Account");
    }



    [HttpGet]
    [Route("/account/savedcourses")]
    public async Task<IActionResult> Savedcourses()
    {
        var viewModel = new AccountSavedCourseViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();

        return View(viewModel);
    }

    public async Task<IActionResult> Courses()
    {
        var viewModel = new CoursesViewModel();

        using var http = new HttpClient();

        var response = await http.GetAsync("https://localhost:7019/api/courses");

        viewModel.Courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(await response.Content.ReadAsStringAsync())!;

        return View(viewModel);
    }

}
