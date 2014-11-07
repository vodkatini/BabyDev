using BabyDev.Data.Contracts;
using BabyDev.Data.Migrations;

namespace BabyDev.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using BabyDev.Models;

    public class BabyDevDbContext : IdentityDbContext<BabyDevUser>, IBabyDevDbContext
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

        public IDbSet<Answer> Answers { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Child> Children { get; set; }

        public IDbSet<Paragraph> Paragraphs { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Topic> Topics { get; set; }
    }
}
