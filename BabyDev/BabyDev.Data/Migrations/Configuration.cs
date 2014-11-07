using BabyDev.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BabyDev.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BabyDevDbContext>
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

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category(){ Name = "Newborn"});
                context.SaveChanges();
            }

            if (!context.Topics.Any())
            {
                var categoryId = context.Categories.FirstOrDefault(c => c.Name == "Newborn").Id;
                var authorId = context.Users.FirstOrDefault(a => a.Email == "user@babydev.com").Id;
                var topic = new Topic() { Title = "Your newborn", AuthorId = authorId, CategoryId = categoryId, RelatedMonths = 0, CreatedOn = DateTime.Now};
                context.Topics.Add(topic);
                context.SaveChanges();
            }

            if (!context.Paragraphs.Any())
            {
                var topicId = context.Topics.FirstOrDefault(t => t.Title == "Your newborn").Id;
                var paragraph = new Paragraph()
                {
                    Subtitle = "How your baby's growing:",
                    Content =
                        "Because he was curled up inside your uterus until recently, your newborn baby will probably look scrunched up for a while, with his arms and legs not fully extended. He may even appear bowlegged. Don't worry: Your baby will stretch out, little by little, and by the time he reaches 6 months, he'll be fully unfurled! In the meantime, as he adjusts to life outside the warm, safe confines of your womb, he may enjoy being swaddled in a light blanket.",
                    TopicId = topicId
                };

                context.Paragraphs.Add(paragraph);
                context.SaveChanges();
            }
        }
    }
}
