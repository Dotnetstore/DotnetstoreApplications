using Dotnetstore.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnetstore.Domain.Business;

public class Employee : PersonIdentity
{
    public Guid OwnCompanyID { get; set; }

    [ForeignKey(nameof(OwnCompanyID))]
    public virtual OwnCompany OwnCompany { get; set; }
}