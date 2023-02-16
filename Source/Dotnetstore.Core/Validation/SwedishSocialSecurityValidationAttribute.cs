using Dotnetstore.Core.Structs;
using System.ComponentModel.DataAnnotations;

namespace Dotnetstore.Core.Validation;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class SwedishSocialSecurityValidationAttribute : ValidationAttribute
{
    public SwedishSocialSecurityValidationAttribute()
    {
        ErrorMessage = "Corporate ID is not valid!";
    }

    public SwedishSocialSecurityValidationAttribute(string? errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public override bool IsValid(object? value)
    {
        return value is null || new SwedishSocialSecurityNumber(value.ToString()).IsValid;
    }
}