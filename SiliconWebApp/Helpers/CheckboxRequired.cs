using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.Helpers;

public class CheckboxRequired
{
    public class CheckBoxRequired : ValidationAttribute
    {
        public override bool IsValid(object? value) => value is bool b && b;
    }

}
