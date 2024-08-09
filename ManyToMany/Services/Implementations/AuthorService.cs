using ManyToMany.Contexts;
using ManyToMany.Models;
using ManyToMany.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ManyToMany.Services.Implementations;

public class AuthorService : IAuthorService
{
    private readonly AppDbContext _context;
    public AuthorService()
    {
        _context = new AppDbContext();
    }

    public async Task CreateAuthorAsync(Author author)
    {
        await _context.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public void Test()
    {
        Console.WriteLine("test");
    }
}
