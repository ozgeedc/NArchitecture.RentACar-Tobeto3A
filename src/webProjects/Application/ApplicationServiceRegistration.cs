using Core.CrossCutting.Logging.Serilog;
using Core.CrossCutting.Logging.Serilog.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using Core.Application.Pipelines.Validation;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(RequestValidationBehavior<,>));
        services.AddSingleton<LoggerServiceBase, MongoDbLogger>();
        return services;
    }
}
