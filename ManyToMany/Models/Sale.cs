using ManyToMany.Models.Common;

namespace ManyToMany.Models;

public class Sale : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int BookCount { get; set; }
    public decimal TotalPrice { get; set; }
}