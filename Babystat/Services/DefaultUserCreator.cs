using System;
using System.Linq;
using Babystat.Data;
using Babystat.Models;
using Microsoft.AspNetCore.Identity;

namespace Babystat.Services
{
    public class DefaultUserCreator : IDefaultUserCreator
    {
        ApplicationDbContext context { get; set; }
        UserManager<ApplicationUser> userManager { get; set; }

        public DefaultUserCreator(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public void CreateDefaultUser()
        {
            if (!context.Users.Any(x => x.UserName == "username"))
            {
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
