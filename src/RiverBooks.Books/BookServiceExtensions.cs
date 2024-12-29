using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Books.Data;
using RiverBooks.Books.Repository;
using RiverBooks.Books.Service;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
    public static void AddBookService(this WebApplicationBuilder builder)
    {
        Console.WriteLine("=============AddBookService============");
        var connectionString = builder.Configuration.GetConnectionString("BooksConnectionString");
        builder.Services.AddDbContext<BookDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
        
        builder.Services.AddScoped<IBookRepository, EfBookRepository>();
        builder.Services.AddScoped<IBookService, BookService>();
    }
}