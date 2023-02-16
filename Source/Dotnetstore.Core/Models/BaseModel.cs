using Dotnetstore.Core.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnetstore.Core.Models;

[Index(nameof(ID), IsUnique = true)]
public class BaseModel : Disposable
{
    public Guid? CreatedByID { get; set; }

    [Required]
    public DateTimeOffset? CreatedDate { get; set; }

    public Guid? DeletedByID { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }

    [Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? ID { get; set; }

    [Required]
    public bool? IsDeleted { get; set; }

    [Required]
    public bool? IsGDPR { get; set; }

    [Required]
    public bool? IsSystem { get; set; }

    public bool? IsUpdated { get; set; }

    [Required]
    public bool? IsVisible { get; set; }

    public Guid? LastUpdatedByID { get; set; }

    public DateTimeOffset? LastUpdatedDate { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            ID = null;
            CreatedByID = null;
            CreatedDate = null;
            LastUpdatedByID = null;
            DeletedByID = null;
            LastUpdatedDate = null;
            DeletedDate = null;
            RowVersion = null;
            IsDeleted = null;
            IsGDPR = null;
            IsSystem = null;
            IsUpdated = null;
            IsVisible = null;
        }

        base.DisposeManaged();
    }
}