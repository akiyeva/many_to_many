using ManyToMany.Models.Common;

namespace ManyToMany.Models;

public class Author : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
