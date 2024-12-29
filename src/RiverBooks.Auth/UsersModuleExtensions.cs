using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.User;

namespace RiverBooks.Auth;

public static class UsersModuleExtensions
{
    public static void AddUserModuleServices(this WebApplicationBuilder builder)
    {
        Console.WriteLine("=============AddUserModule============");
        var connectionString = builder.Configuration.GetConnectionString("UsersModuleConnectionString");

        builder.Services.AddDbContext<UsersDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });

        builder.Services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<UsersDbContext>();
    }
}