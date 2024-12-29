using FastEndpoints;
using RiverBooks.Books.Service;

namespace RiverBooks.Books.Endpoints.Get;

internal class ListBooksEndpoints(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellation)
    {
        var books = await bookService.ListBooksAsync();

        await SendAsync(new ListBooksResponse()
        {
            Books = books
        }, cancellation: cancellation);
    }
}