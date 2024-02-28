﻿using Infrastructure.Models;

namespace SiliconWebApp.ViewModels;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign Up";
    public SignUpModel Form { get; set; } = new SignUpModel();
}
