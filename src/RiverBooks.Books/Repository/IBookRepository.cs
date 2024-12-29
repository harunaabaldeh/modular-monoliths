using RiverBooks.Books.Data;

namespace RiverBooks.Books.Repository;

internal interface IBookRepository : IReadOnlyBookRepository
{
    Task AddAsync(Book book);
    Task DeleteAsync(Book book);
    Task SaveChangesAsync();
}