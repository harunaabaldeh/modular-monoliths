

using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Auth;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    private List<CartItem> _cartItems { get; set; } = new();
    public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

    public void AddCartItem(CartItem item)
    {
        Guard.Against.Null(item);
        
        var existingBook = _cartItems.FirstOrDefault(x => x.BookId == item.BookId);
        if (existingBook is not null)
        {
            existingBook.UpdateQuantity(existingBook.Quantity + item.Quantity);
            // TODO: What to do if other details of the book have been update?
            return;
        }
        _cartItems.Add(item);
    }
}

public class CartItem
{
    public CartItem(Guid bookId, string description, int quantity, decimal unitPrice)
    {
        BookId = Guard.Against.Null(bookId);
        Description = Guard.Against.Null(description);
        Quantity = Guard.Against.Negative(quantity);
        UnitPrice = Guard.Against.Negative(unitPrice);
    }

    public CartItem()
    {
        // EF
    }
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid BookId { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    internal void UpdateQuantity(int quantity)
    {
        Quantity = Guard.Against.Null(quantity);
    }
}