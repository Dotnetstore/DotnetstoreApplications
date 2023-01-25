namespace Dotnetstore.Shared.Business;

public class BaseModelDto
{
    public Guid? CreatedByID { get; set; }

    public DateTimeOffset? CreatedDate { get; set; }

    public Guid? DeletedByID { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }

    public Guid? ID { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsGDPR { get; set; }

    public bool? IsSystem { get; set; }

    public bool? IsUpdated { get; set; }

    public bool? IsVisible { get; set; }

    public Guid? LastUpdatedByID { get; set; }

    public DateTimeOffset? LastUpdatedDate { get; set; }

    public byte[]? RowVersion { get; set; }
}