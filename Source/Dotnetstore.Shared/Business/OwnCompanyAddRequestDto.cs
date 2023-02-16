using System.ComponentModel.DataAnnotations;
using Dotnetstore.Shared.Common;

namespace Dotnetstore.Shared.Business;

public class OwnCompanyAddRequestDto : UserIDDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(100, MinimumLength = 3)]
    [MinLength(3)]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(600, MinimumLength = 3)]
    [MinLength(3)]
    [MaxLength(600)]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [StringLength(20, MinimumLength = 0)]
    [MinLength(0)]
    [MaxLength(20)]
    [DataType(DataType.Text)]
    public string? CorporateID { get; set; }
}