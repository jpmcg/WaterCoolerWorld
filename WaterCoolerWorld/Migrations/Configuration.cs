using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WaterCoolerWorld.Models;

namespace WaterCoolerWorld.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WaterCoolerWorld.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WaterCoolerWorld.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
          /*  var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var passwordHash = new PasswordHasher();

            if (!context.Users.Any(u => u.UserName == "Andrew"))
            {
                var user = new ApplicationUser
                {
                    UserName = "Andrew",
                    Email = "andrew@andrew.com",
                    PasswordHash = passwordHash.HashPassword("123456")
                };
                userManager.Create(user);
            }*/
        }
    }
}
