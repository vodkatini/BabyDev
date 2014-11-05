using BabyDev.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BabyDev.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BabyDevDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BabyDevDbContext context)
        {
            if (!context.Users.Any(u => u.Email == "user@babydev.com"))
            {
                var store = new UserStore<BabyDevUser>(context);
                var manager = new UserManager<BabyDevUser>(store);
                var user = new BabyDevUser { UserName = "user@babydev.com", Email = "user@babydev.com" };

                manager.Create(user, "123456");
            }
        }
    }
}
