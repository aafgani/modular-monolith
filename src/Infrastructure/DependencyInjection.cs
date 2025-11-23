using System;
using Application.Abstractions.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Repository
        services.AddDbContext<PagilaDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Default"));
            });
        services.AddScoped<IActorRepository, ActorRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        return services;
    }
}
