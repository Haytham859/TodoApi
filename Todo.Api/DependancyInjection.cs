using Microsoft.EntityFrameworkCore;
using Todo.Application;
using Todo.Application.Contracts;
using Todo.Application.Implementation;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure;
using Todo.Infrastructure.Persistence.Entities;
using Todo.Infrastructure.Repository;

namespace Todo.Api;

public static class DependancyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString=configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<TodoAppDbContext>(options=>options.UseSqlServer(connectionString));

        
        services.AddAutoMapper(typeof(InfraAssemplyMarker).Assembly);
    services.AddAutoMapper(typeof(ApplicationLayerMarker).Assembly);
        services.AddScoped<IUserRepo, UserRepo>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}