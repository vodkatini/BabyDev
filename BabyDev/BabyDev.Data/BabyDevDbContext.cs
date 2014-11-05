using BabyDev.Data.Migrations;

namespace BabyDev.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using BabyDev.Models;

    public class BabyDevDbContext : IdentityDbContext<BabyDevUser>
    {
        public BabyDevDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BabyDevDbContext, Configuration>());
        }

        public static BabyDevDbContext Create()
        {
            return new BabyDevDbContext();
        }
    }
}
