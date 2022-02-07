using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("BlogDb"));
        services.AddScoped<IApplicationDbContext>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());
        services.AddSingleton<IDomainEventService, DomainEventService>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IPaginate, PaginateService>();

        return services;
    }
}