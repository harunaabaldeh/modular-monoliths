namespace RiverBooks.Auth.CartEndpoints;

internal record AddCardItemRequest(Guid BookId, int Quantity);