namespace Dotnetstore.Business.Models;

public class Person : BaseModel
{
    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25)]
    [MinLength(1)]
    [MaxLength(25)]
    [DataType(DataType.Text)]
    public string? LastName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25)]
    [MinLength(1)]
    [MaxLength(25)]
    [DataType(DataType.Text)]
    public string? FirstName { get; set; }

    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25, MinimumLength = 0)]
    [MinLength(0)]
    [MaxLength(25)]
    [DataType(DataType.Text)]
    public string? MiddleName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Column(TypeName = "varchar(255)")]
    [StringLength(255, MinimumLength = 6)]
    [MinLength(6)]
    [MaxLength(255)]
    [DataType(DataType.EmailAddress)]
    public string? RegisterEmailAddress { get; set; }

    [Required]
    public bool? LastNameFirst { get; set; }

    [Column(TypeName = "varchar(20)")]
    [StringLength(20, MinimumLength = 0)]
    [MinLength(0)]
    [MaxLength(20)]
    [DataType(DataType.Text)]
    public string? SocialSecurityNumber { get; set; }

    [Column(TypeName = "nvarchar(25)")]
    [StringLength(25, MinimumLength = 1)]
    [MinLength(1)]
    [MaxLength(25)]
    [DataType(DataType.Text)]
    public string? EnglishName { get; set; }

    public override string ToString()
    {
        string? name;

        if (LastNameFirst.HasValue &&
            LastNameFirst.Value)
        {
            name = $"{LastName}, {FirstName}";

            if (!string.IsNullOrEmpty(MiddleName))
                name += $" {MiddleName}";
        }
        else
        {
            name = FirstName;

            if (!string.IsNullOrEmpty(MiddleName))
                name += $" {MiddleName}";

            name += $" {LastName}";
        }

        return name;
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            LastName = null;
            FirstName = null;
            MiddleName = null;
            RegisterEmailAddress = null;
            SocialSecurityNumber = null;
            EnglishName = null;
            LastNameFirst = null;
        }

        base.DisposeManaged();
    }
}