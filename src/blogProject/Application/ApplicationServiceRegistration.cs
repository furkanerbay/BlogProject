using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.ElasticSearch;
using Core.Mailing;
using FluentValidation;
using Core.Mailing.MailKitImplementations;
using Application.Services.EntityService.AuthService;
using Application.Services.EntityService.AuthenticatorService;
using Application.Services.EntityService.UserService;
using Application.Services.EntityService.ApplicationUserService;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            //configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            //configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            //configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            //configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            //configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.AddScoped<IAdditionalServiceService, AdditionalServiceManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        //services.AddScoped<ICarService, CarManager>();
        //services.AddScoped<ICustomerService, CustomerManager>();
        //services.AddScoped<IFindeksCreditRateService, FindeksCreditRateManager>();
        //services.AddScoped<IInvoiceService, InvoiceManager>();
        //services.AddScoped<IModelService, ModelManager>();
        //services.AddScoped<IRentalService, RentalManager>();
        //services.AddScoped<IRentalsAdditionalServiceService, RentalsAdditionalServiceManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IApplicationUserService, ApplicationUserManager>();

        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();

        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}