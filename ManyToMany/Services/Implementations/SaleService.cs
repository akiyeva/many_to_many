using ManyToMany.Contexts;
using ManyToMany.DTOs.SaleDtos;
using ManyToMany.Exceptions;
using ManyToMany.Models;
using ManyToMany.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Services.Implementations;

public class SaleService : ISaleService
{
    private readonly AppDbContext _context;

    public SaleService()
    {
        _context = new AppDbContext();
    }

    public async Task AddSaleAsync(SaleDto saleDto)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == saleDto.BookId);
        if (book == null)
            throw new NotFoundException($"Book not found by id: {saleDto.BookId}");

        if (book.StockCount < saleDto.Count)
            throw new StockCountException($"There not enough stock count: {book.StockCount}");

        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == saleDto.CustomerId);
        if (customer == null)
            throw new NotFoundException($"Customer not found by id: {saleDto.CustomerId}");

        Sale sale = new Sale
        {
            BookId = saleDto.BookId,
            CustomerId = saleDto.CustomerId,
            BookCount = saleDto.Count,
            TotalPrice = book.Price * saleDto.Count
        };
        book.StockCount -= saleDto.Count;
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Sale>> GetAllSalesAsync()
    {
        var sales = await _context.Sales.Include(s => s.Book).ThenInclude(b => b.Author).Include(s => s.Customer).ToListAsync();
        return sales;
    }
}