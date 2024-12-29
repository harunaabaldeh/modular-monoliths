using Ardalis.Result;
using MediatR;

namespace RiverBooks.Auth.UseCases;

internal record AddItemToCartCommand(Guid BookId, int Quantity, string EmailAddress) : IRequest<Result>;

internal class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, Result>
{
    private readonly IApplicationUserRepository _userRepository;
    public AddItemToCartCommandHandler(IApplicationUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithCartByEmailAsync(request.EmailAddress);

        if (user is null)
        {
            return Result.Unauthorized();
        }
        
        // TODO: Get description and price from books module
        var newCartItem = new CartItem(request.BookId, "description", request.Quantity, 1.00m);
        
        user.AddCartItem(newCartItem);

        await _userRepository.SaveChangesAsync();

        return Result.Success();
    }
}