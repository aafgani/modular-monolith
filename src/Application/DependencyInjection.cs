using System;
using Application.Abstractions.Mapper;
using Application.Abstractions.Service;
using Application.Behavior.Validation;
using Application.Mapper;
using Application.Service;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Validators
        services.AddValidatorsFromAssemblyContaining<CreateActorValidator>();
        #endregion

        #region Mappers
        services.AddSingleton<IActorMapper, ActorMapper>();
        #endregion

        #region Services
        services.AddSingleton<IActorService, ActorService>();
        #endregion

        return services;
    }

}
