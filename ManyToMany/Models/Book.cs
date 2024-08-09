using ManyToMany.Models.Common;

namespace ManyToMany.Models;

public class Book : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockCount { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public List<Sale> Sales { get; set; }
}