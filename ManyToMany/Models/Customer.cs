using ManyToMany.Models.Common;

namespace ManyToMany.Models;

public class Customer : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<Sale> Sales { get; set; }
}