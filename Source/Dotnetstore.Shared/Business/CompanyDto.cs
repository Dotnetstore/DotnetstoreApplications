using Dotnetstore.Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace Dotnetstore.Shared.Business;

public class CompanyDto : BaseInfoModelDto
{
    [StringLength(20, MinimumLength = 0)]
    [MinLength(0)]
    [MaxLength(20)]
    [DataType(DataType.Text)]
    [SwedishSocialSecurityValidation]
    public string? CorporateID { get; set; }
}