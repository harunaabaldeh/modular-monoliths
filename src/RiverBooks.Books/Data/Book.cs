using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using RiverBooks.Books.Repository;

namespace RiverBooks.Books.Data;

internal class EfBookRepository : IBookRepository
{
    private readonly BookDbContext _dbContext;

    public EfBookRepository(BookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Books.FindAsync(id);
    }

    public async Task<List<Book>> ListAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public Task AddAsync(Book book)
    {
        _dbContext.Books.Add(book);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Book book)
    {
        _dbContext.Remove(book);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}

internal class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public decimal Price { get; private set; }

    internal Book(Guid id, string title, string author, decimal price)
    {
        Id = Guard.Against.Default(id);
        Title = Guard.Against.NullOrWhiteSpace(title);
        Author = Guard.Against.NullOrWhiteSpace(author);
        Price = Guard.Against.Negative(price);
    }

    internal void UpdatePrice(decimal price)
    {
        Price = Guard.Against.Negative(price);
    }
}