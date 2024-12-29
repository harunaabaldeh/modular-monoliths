namespace RiverBooks.Books.Endpoints.Update;

internal record UpdateBookPriceRequest(Guid Id, decimal Price);