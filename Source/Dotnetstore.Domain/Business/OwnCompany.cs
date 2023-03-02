using Dotnetstore.Domain.Shared;

namespace Dotnetstore.Domain.Business;

public class OwnCompany : Company
{
    public virtual ICollection<Employee> Employees { get; set; }
}