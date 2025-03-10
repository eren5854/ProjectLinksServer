using Microsoft.AspNetCore.Identity;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Middlewares;

public static class ExtensionMiddleware
{
    public static void CreateUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any(a => a.Email == "info@erendelibas.com"))
            {
                AppUser appUser = new()
                {
                    Email = "info@erendelibas.com",
                    UserName = "Eren",
                    EmailConfirmed = true,

                };
                userManager.CreateAsync(appUser, "Password123*").Wait();
            }
        }
    }
}
