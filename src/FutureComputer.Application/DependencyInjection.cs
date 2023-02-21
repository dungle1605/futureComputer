using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using FutureComputer.Application.Configs;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FutureComputer.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServicesApplication(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // Fluent Validation
        // More details: https://docs.fluentvalidation.net/en/latest/aspnet.html
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(MappingProfile<,>));

        return services;
    }
}
