using ManyToMany.Models;
using ManyToMany.Repositories.Implementations.Generic;
using ManyToMany.Repositories.Interfaces;

namespace ManyToMany.Repositories.Implementations;

public class BookRepository:Repository<Book>,IBookRepository
{
}
