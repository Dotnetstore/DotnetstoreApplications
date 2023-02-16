using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnetstore.Core.Models;

public class BaseInfoModel : BaseModel
{
    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "nvarchar(100)")]
    [StringLength(100, MinimumLength = 3)]
    [MinLength(3)]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "nvarchar(600)")]
    [StringLength(600, MinimumLength = 3)]
    [MinLength(3)]
    [MaxLength(600)]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            Name = null;
            Description = null;
        }

        base.DisposeManaged();
    }
}