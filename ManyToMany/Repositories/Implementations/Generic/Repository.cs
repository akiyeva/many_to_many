using ManyToMany.Contexts;
using ManyToMany.Models.Common;
using ManyToMany.Repositories.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ManyToMany.Repositories.Implementations.Generic;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public Repository()
    {
        _context = new AppDbContext();
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<List<T>> GetAllAsync(params string[] includes) //"Author" ,"Sales.Customer"
    {
        var query = _context.Set<T>().AsQueryable(); //Select*from Books join Author


        foreach (var include in includes)
        {
            query = query.Include(include);  //Select*from Books b join Author a on b.AuthorId=a.Id  join Sales s  on b.SalesId=s.Id  join Customer c s.CustomerId=c.Id 
        }


        var result = await query.ToListAsync(); //List<Book> books


        return result;
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }


        var result = await query.FirstOrDefaultAsync(predicate);

        return result;
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
    {
        var result = await _context.Set<T>().AnyAsync(predicate);

        return result;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
