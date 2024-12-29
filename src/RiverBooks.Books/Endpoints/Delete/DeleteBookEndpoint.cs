using FastEndpoints;
using RiverBooks.Books.Service;

namespace RiverBooks.Books.Endpoints.Delete;

internal class DeleteBookEndpoint(IBookService bookService) : Endpoint<DeleteBookRequest>
{
    public override void Configure()
    {
        Delete("/books/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteBookRequest request, CancellationToken ct)
    {
        await bookService.DeleteBookAsync(request.Id);

        await SendNoContentAsync(ct);
    }
}