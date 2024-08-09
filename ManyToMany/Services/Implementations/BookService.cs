using ManyToMany.Contexts;
using ManyToMany.DTOs.BookDtos;
using ManyToMany.Exceptions;
using ManyToMany.Models;
using ManyToMany.Repositories.Implementations;
using ManyToMany.Repositories.Interfaces;
using ManyToMany.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Services.Implementations;

public class BookService : IBookService
{
    //private readonly AppDbContext _context;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    public BookService()
    {
        _bookRepository = new BookRepository();
        _authorRepository = new AuthorRepository();
        //_context = new AppDbContext();
    }

    public async Task CreateBookAsync(BookPostDto newBook)
    {

        var isExistAuthor = await _authorRepository.IsExistAsync(x => x.Id == newBook.AuthorId);

        if (!isExistAuthor)
            throw new NotFoundException("this author is not found");

        Book book = new Book()
        {
            AuthorId = newBook.AuthorId,
            CreatedDate = DateTime.UtcNow,
            Description = newBook.Description,
            Name = newBook.Name,
            Price = newBook.Price,
            StockCount = newBook.StockCount,
            UpdatedDate = DateTime.UtcNow,


        };

        await _bookRepository.CreateAsync(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _getBookById(id);

        _bookRepository.Delete(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task<List<BookGetDto>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync("Author","Sales");

        List<BookGetDto> result = new List<BookGetDto>();

        books.ForEach(book =>
        {
            BookGetDto bookGet = new BookGetDto()
            {
                Author = book.Author,
                Name = book.Name,
                AuthorId = book.AuthorId,
                Description = book.Description,
                Id = book.Id,
                Price = book.Price,
                StockCount = book.StockCount,
            };
            result.Add(bookGet);
        });

        return result;
    }

    public async Task<BookGetDto> GetBookByIdAsync(int id)
    {
        var book = await _getBookById(id);

        BookGetDto dto = new()
        {
            Author = book.Author,
            Name = book.Name,
            AuthorId = book.AuthorId,
            Description = book.Description,
            Id = book.Id,
            Price = book.Price,
            StockCount = book.StockCount,
        };

        return dto;
    }

    public async Task UpdateBookAsync(BookPutDto newBook)
    {
        Book? book = await _getBookById(newBook.Id);

        book.Name = newBook.Name;
        book.AuthorId = newBook.AuthorId;
        book.Description = newBook.Description;
        book.StockCount = newBook.StockCount;
        book.UpdatedDate = DateTime.UtcNow;

        _bookRepository.Update(book);
        await _bookRepository.SaveChangesAsync();
    }

    private async Task<Book> _getBookById(int id)
    {
        var book = await _bookRepository.GetSingleAsync(x => x.Id == id);

        if (book is null)
            throw new NotFoundException("Book is not found");


        return book;
    }




    //public async Task CreateBookAsync(BookPostDto newBook)
    //{



    //var isExistAuthor = await _context.Authors.AnyAsync(x => x.Id == newBook.AuthorId);

    //    if (!isExistAuthor)
    //        throw new NotFoundException("Author is not found");


    //    Book book = new Book
    //    {
    //        Name = newBook.Name,
    //        Description = newBook.Description,
    //        Price = newBook.Price,
    //        StockCount = newBook.StockCount,
    //        CreatedDate = DateTime.UtcNow,
    //        UpdatedDate = DateTime.UtcNow,
    //        AuthorId = newBook.AuthorId
    //    };

    //    await _context.Books.AddAsync(book);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task<List<BookGetDto>> GetAllBooksAsync()
    //{
    //    var books = await _context.Books.Include("Author").ToListAsync();
    //    List<BookGetDto> bookList = new List<BookGetDto>();
    //    foreach (var book in books) 
    //    {
    //        bookList.Add(new BookGetDto
    //        {
    //            Name = book.Name,
    //            Description = book.Description,
    //            Price = book.Price,
    //            StockCount = book.StockCount,
    //            AuthorId = book.AuthorId,
    //            Author = book.Author
    //        });
    //    }
    //    return bookList;
    //}
}