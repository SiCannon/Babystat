using System.Linq;
using Babystat.Controllers;
using Babystat.Models.AccountViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Babystat.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(this IApplicationBuilder app)
        {
            using (var db = app.ApplicationServices.GetService<ApplicationDbContext>())
            {
                // nothing yet...
            }
        }
    }
}
