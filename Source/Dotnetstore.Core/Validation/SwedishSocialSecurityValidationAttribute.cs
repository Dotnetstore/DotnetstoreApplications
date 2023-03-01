using Dotnetstore.Core.Structs;
using System.ComponentModel.DataAnnotations;

namespace Dotnetstore.Core.Validation;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class SwedishSocialSecurityValidationAttribute : ValidationAttribute
{
    private bool _isNullable;

    public SwedishSocialSecurityValidationAttribute(bool isNullable)
    {
        ErrorMessage = "Corporate ID is not valid!";
        _isNullable = isNullable;
    }

    public SwedishSocialSecurityValidationAttribute(bool isNullable, string? errorMessage)
    {
        ErrorMessage = errorMessage;
        _isNullable = isNullable;
    }

    public override bool IsValid(object? value)
    {
        var number = value?.ToString();

        if (_isNullable)
        {
            return string.IsNullOrWhiteSpace(number) || new SwedishSocialSecurityNumber(number).IsValid;
        }

        return new SwedishSocialSecurityNumber(number ?? "").IsValid;
    }
}