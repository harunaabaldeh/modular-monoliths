using FastEndpoints;
using RiverBooks.Books.Service;

namespace RiverBooks.Books.Endpoints.Update;

internal class UpdateBookEndpoint(IBookService bookService) : Endpoint<UpdateBookPriceRequest, BookDto>
{
    public override void Configure()
    {
        Post("books/{Id}/price");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateBookPriceRequest request, CancellationToken ct)
    {
        await bookService.UpdateBookPriceAsync(request.Id, request.Price);
        
        var updatedBook = await bookService.GetBookByIdAsync(request.Id);
        
        await SendAsync(updatedBook, cancellation: ct);
    }
}