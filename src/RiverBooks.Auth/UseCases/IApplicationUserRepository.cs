using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Auth.UseCases;

internal interface IApplicationUserRepository
{
    Task<ApplicationUser> GetUserWithCartByEmailAsync(string emailAddress);
    Task SaveChangesAsync();
}

internal class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly UsersDbContext _usersDbContext;

    public ApplicationUserRepository(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }

    public Task<ApplicationUser> GetUserWithCartByEmailAsync(string emailAddress)
    {
        return _usersDbContext.ApplicationUsers
            .Include(user => user.CartItems)
            .SingleOrDefaultAsync(user => user.Email == emailAddress)!;
    }

    public Task SaveChangesAsync()
    {
        return _usersDbContext.SaveChangesAsync();
    }
}