using ManyToMany.Models;

namespace ManyToMany.Services.Interfaces;

public interface IAuthorService
{
    Task<List<Author>> GetAllAuthorsAsync();
    Task CreateAuthorAsync(Author author);
    Task DeleteAuthorAsync(int id);
    Task<Author> GetAuthorByIdAsync(int id);
    Task UpdateAuthorAsync(Author author);
}