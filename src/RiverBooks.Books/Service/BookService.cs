using RiverBooks.Books.Data;
using RiverBooks.Books.Repository;

namespace RiverBooks.Books.Service;

internal class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> ListBooksAsync()
    {
        var books = (await _bookRepository.ListAsync())
            .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Price))
            .ToList();

        return books;
    }

    public async Task<BookDto> GetBookByIdAsync(Guid bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);

        return new BookDto(book!.Id, book.Title, book.Author, book.Price);
    }

    public async Task CreateBookAsync(BookDto newBook)
    {
        var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);

        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid bookId)
    {
        var bookToDelete = await _bookRepository.GetByIdAsync(bookId);

        if (bookToDelete is not null)
        {
            await _bookRepository.DeleteAsync(bookToDelete);
            await _bookRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateBookPriceAsync(Guid bookId, decimal newPrice)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);

        book!.UpdatePrice(newPrice);
    }
}