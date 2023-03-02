using Dotnetstore.Core.Structs;
using System.ComponentModel.DataAnnotations;

namespace Dotnetstore.Core.Validation;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class SwedishSocialSecurityValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        ErrorMessage = "Wrong format";
        var number = value?.ToString();

        if (string.IsNullOrEmpty(number))
        {
            return true;
        }

        return string.IsNullOrWhiteSpace(number) || new SwedishSocialSecurityNumber(number).IsValid;
    }
}