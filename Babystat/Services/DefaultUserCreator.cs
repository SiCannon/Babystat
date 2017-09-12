using System;
using System.Linq;
using Babystat.Data;
using Babystat.Models;
using Babystat.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Babystat.Services
{
    public class DefaultUserCreator : IDefaultUserCreator
    {
        ApplicationDbContext context { get; set; }
        UserManager<ApplicationUser> userManager { get; set; }
        DefaultUserOptions defaultUserOptions { get; set; }

        public DefaultUserCreator(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IOptions<DefaultUserOptions> defaultUserOptionsAccessor)
        {
            this.context = context;
            this.userManager = userManager;
            defaultUserOptions = defaultUserOptionsAccessor.Value;
        }

        public void CreateDefaultUser()
        {
            if (!context.Users.Any(x => x.UserName == defaultUserOptions.Username))
            {
                var user = new ApplicationUser { UserName = defaultUserOptions.Username, Email = defaultUserOptions.Email};
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
