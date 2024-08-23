using eAppointmentServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eAppointmentServer.WebAPI;

public static class CreateAdmin
{
    public static async Task CreateAdminAsync(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any())
            {
                var result = await userManager.CreateAsync(new()
                {
                    FirstName = "Berkay",
                    LastName = "Kaplan",
                    Email = "admin@admin.com",
                    UserName = "admin",
                }, "admin123");

                if (!result.Succeeded)
                {
                    // Hataları loglayın veya hata ile ilgili detayları kontrol edin.
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Admin user could not be created: {errors}");
                }
            }
        }
    }
}


