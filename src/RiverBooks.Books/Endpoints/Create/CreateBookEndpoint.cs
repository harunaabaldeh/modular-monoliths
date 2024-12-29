using FastEndpoints;
using RiverBooks.Books.Endpoints.Get;
using RiverBooks.Books.Service;

namespace RiverBooks.Books.Endpoints.Create;

internal class CreateBookEndpoint(IBookService bookService) : Endpoint<CreateBookRequest, BookDto>
{
    public override void Configure()
    {
        Post("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookRequest request, CancellationToken ct)
    {
        var newBook = new BookDto(request.Id, request.Title, request.Author, request.Price);

        await bookService.CreateBookAsync(newBook);

        await SendCreatedAtAsync<GetBookByIdEndpoint>(new { Id = newBook.Id }, newBook, cancellation: ct);
    }
}