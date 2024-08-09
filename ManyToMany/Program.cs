using ManyToMany.DTOs.BookDtos;
using ManyToMany.Models;
using ManyToMany.Services.Implementations;

//AuthorService authorService = new AuthorService();


//Author author = new()
//{
//     Name="Aslan"
//};

//await authorService.CreateAuthorAsync(author);

BookService bookService = new BookService();


//BookPostDto book = new()
//{
//    Name = "Sefiller",
//    AuthorId = 1,
//    Description = "Salam",
//    Price = 100,
//    StockCount = 100,

//};

//await bookService.CreateBookAsync(book);



var books = await bookService.GetAllBooksAsync();

