using System.Reflection;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using RiverBooks.Auth;
using RiverBooks.Books;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddFastEndpoints()
        .AddJWTBearerAuth(builder.Configuration["Auth:JwtSecret"]!)
        .AddAuthorization()
        .SwaggerDocument();

    // Add Module services
    List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
    builder.AddBookService(mediatRAssemblies);
    builder.AddUserModuleServices(mediatRAssemblies);
    
    // Setup MediatR
    builder.Services.AddMediatR(cfg => 
        cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));
}


var app = builder.Build();
{
    app.UseAuthentication();
    app.UseAuthorization();
    
    app.UseFastEndpoints()
        .UseSwaggerGen();

    app.Run();
}

public partial class Program
{
} // needed for testing