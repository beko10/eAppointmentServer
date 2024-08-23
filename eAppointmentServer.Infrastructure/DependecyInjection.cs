using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Scrutor;

namespace eAppointmentServer.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        services.AddIdentity<AppUser, AppRole>(action =>
        {
            action.Password.RequireDigit = true; // Rakam gereksinimi
            action.Password.RequiredLength = 5;  // Minimum uzunluk
            action.Password.RequireNonAlphanumeric = false; // Alfasayısal olmayan karakter gereksinimi devre dışı bırakıldı
            action.Password.RequireUppercase = false; // Büyük harf gereksinimi devre dışı bırakıldı
            action.Password.RequireLowercase = false; // Küçük harf gereksinimi devre dışı bırakıldı 

        }).AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        services.Scan(action =>
        {
            action
            .FromAssemblies(typeof(DependecyInjection).Assembly)
            .AddClasses(publicOnly:false)
            .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime(); 
        });


        return services;
    }
}
