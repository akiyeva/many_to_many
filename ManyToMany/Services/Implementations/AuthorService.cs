using ManyToMany.Contexts;
using ManyToMany.Exceptions;
using ManyToMany.Models;
using ManyToMany.Repositories.Implementations;
using ManyToMany.Repositories.Interfaces;
using ManyToMany.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ManyToMany.Services.Implementations;

public class AuthorService : IAuthorService
{
    //private readonly AppDbContext _context;
    private readonly IAuthorRepository _authorRepository;
    public AuthorService()
    {
        //_context = new AppDbContext();
        _authorRepository = new AuthorRepository();
    }

    public async Task CreateAuthorAsync(Author newAuthor)
    {
        var isExist = await _authorRepository.IsExistAsync(x => x.Name == newAuthor.Name);
        if (isExist)
        {
            Console.WriteLine("this author is already exists");
            return;
        }
        Author author = new Author()
        {
            Name = newAuthor.Name
        };
        await _authorRepository.CreateAsync(author);
        await _authorRepository.SaveChangesAsync();
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
      var authors = await _authorRepository.GetAllAsync();
      return authors;
    }

    public async Task UpdateAuthorAsync(Author newAuthor)
    {
        Author? author = await GetAuthorByIdAsync(newAuthor.Id);

        author.Name = newAuthor.Name;

        _authorRepository.Update(author);
        await _authorRepository.SaveChangesAsync();
    }
    public async Task DeleteAuthorAsync(int id)
    {
        var author = await GetAuthorByIdAsync(id);

        _authorRepository.Delete(author);
        await _authorRepository.SaveChangesAsync();

    }
    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        var author = await _authorRepository.GetSingleAsync(x => x.Id == id);
        if (author is null)
            throw new NotFoundException("Author is not found");
        return author;
    }

  
}
