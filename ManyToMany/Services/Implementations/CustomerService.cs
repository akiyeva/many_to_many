using ManyToMany.Contexts;
using ManyToMany.Models;
using ManyToMany.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;
    public CustomerService()
    {
        _context = new AppDbContext();
    }

    public async Task CreateCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.Include(c => c.Sales).ThenInclude(s => s.Book).ThenInclude(b => b.Author).ToListAsync();
    }
}