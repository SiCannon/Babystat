using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Babystat.Models;
using Babystat.Data.Entity;

namespace Babystat.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Baby> Babies { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Settings> Settings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Settings>()
                .HasOne(t => t.ActiveBaby)
                .WithMany(t => t.Settings)
                .HasForeignKey(t => t.ActiveBabyId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
