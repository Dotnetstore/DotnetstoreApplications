using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnetstore.Domain.Shared;

public class PersonIdentity : Person
{
    [Display(AutoGenerateField = true)]
    [Column(TypeName = "varchar(25)")]
    [StringLength(25, MinimumLength = 6)]
    [MinLength(6)]
    [MaxLength(25)]
    [DataType(DataType.Password)]
    public string? Username { get; set; }

    [Display(AutoGenerateField = true)]
    [Column(TypeName = "varchar(25)")]
    [StringLength(25, MinimumLength = 6)]
    [MinLength(6)]
    [MaxLength(25)]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            Username = null;
            Password = null;
        }

        base.DisposeManaged();
    }
}