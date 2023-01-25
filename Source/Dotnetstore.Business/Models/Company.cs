namespace Dotnetstore.Business.Models;

public class Company : BaseInfoModel
{
    [Column(TypeName = "varchar(20)")]
    [StringLength(20, MinimumLength = 0)]
    [MinLength(0)]
    [MaxLength(20)]
    [DataType(DataType.Text)]
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