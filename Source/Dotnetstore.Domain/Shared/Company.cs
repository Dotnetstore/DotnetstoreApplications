using Dotnetstore.Core.Models;
using Dotnetstore.Core.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnetstore.Domain.Shared;

public class Company : BaseInfoModel
{
    [Column(TypeName = "varchar(20)")]
    [StringLength(20, MinimumLength = 0)]
    [MinLength(0)]
    [MaxLength(20)]
    [DataType(DataType.Text)]
    [SwedishSocialSecurityValidation]
    public string? CorporateID { get; set; }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            CorporateID = null;
        }

        base.DisposeManaged();
    }
}