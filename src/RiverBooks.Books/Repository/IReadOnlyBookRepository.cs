using RiverBooks.Books.Data;

namespace RiverBooks.Books.Repository;

internal interface IReadOnlyBookRepository
{
    Task<Book?> GetByIdAsync(Guid id);
    Task<List<Book>> ListAsync();
}