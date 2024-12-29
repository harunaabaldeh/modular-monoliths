using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Auth.UserEndpoints;

internal record CreateUserRequest(string Email, string Password);

internal class Create : Endpoint<CreateUserRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public Create(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {
        var newUser = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email
        };

        await _userManager.CreateAsync(newUser, request.Password);

        await SendAsync(newUser, cancellation: ct);
    }
}