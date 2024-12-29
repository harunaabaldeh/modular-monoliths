using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;
using RiverBooks.User;

namespace RiverBooks.Auth.UserEndpoints;

internal class Login : Endpoint<LoginRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public Login(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(request.Username);

        if (user is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        var loginSuccessful = await _userManager.CheckPasswordAsync(user!, request.Password);

        if (!loginSuccessful)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        var jwtSecret = Config["Auth:JwtSecret"]!;
        var token = JWTBearer.CreateToken(jwtSecret,
            p => p["EmailAddress"] = user!.Email!);
        
        await SendAsync(token, cancellation: ct);
    }
}