using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Api;

public static class DependancyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString=configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<TodoAppDbContext>(options=>options.UseSqlServer(connectionString));

        return services;
    }
}