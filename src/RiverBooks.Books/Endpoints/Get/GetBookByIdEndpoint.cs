using FastEndpoints;
using RiverBooks.Books.Service;

namespace RiverBooks.Books.Endpoints.Get;

internal class GetBookByIdEndpoint(IBookService bookService) : Endpoint<GetBookByIdRequest, BookDto>
{
    public override void Configure()
    {
        Get("/books/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetBookByIdRequest req, CancellationToken ct)
    {
        var book = await bookService.GetBookByIdAsync(req.Id);

        await SendAsync(book, cancellation: ct);
    }
}