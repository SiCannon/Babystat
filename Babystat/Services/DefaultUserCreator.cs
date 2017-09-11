using System;
using System.Linq;
using Babystat.Data;
using Babystat.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Babystat.Services
{
    public static class DefaultUserCreator
    {
        public static void CreateDefaultUser(this IApplicationBuilder app)
        {
            using (var db = app.ApplicationServices.GetService<ApplicationDbContext>())
            {
                if (!db.Users.Any(x => x.UserName == "username"))
                {
                    var userManager = app.ApplicationServices.GetService<UserManager<ApplicationUser>>();
                    var user = new ApplicationUser { UserName = "username", Email = "email@example.com" };
                    var createTask = userManager.CreateAsync(user, "password");
                    createTask.Wait();
                    if (!createTask.Result.Succeeded)
                    {
                        throw new Exception("Creation of default user failed: " + createTask.Result.ToString());
                    }
                }
            }
        }
    }
}
