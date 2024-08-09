using ManyToMany.Models;

namespace ManyToMany.Services.Interfaces;

public interface IAuthorService
{
    Task<List<Author>> GetAllAuthorsAsync();
    Task CreateAuthorAsync(Author author);
}