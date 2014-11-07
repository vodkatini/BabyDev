using System.Collections.Generic;
using System.IO;
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
                SeedUsers(context);
                SeedCategories(context);
                SeedTopics(context);
                SeedParagraphs(context);
            }
        }

        private void SeedUsers(BabyDevDbContext context)
        {
            var store = new UserStore<BabyDevUser>(context);
            var manager = new UserManager<BabyDevUser>(store);
            var user = new BabyDevUser { UserName = "user@babydev.com", Email = "user@babydev.com" };

            manager.Create(user, "123456");
        }

        private void SeedCategories(BabyDevDbContext context)
        {
            var categories = new List<Category>()
            {
                new Category() {Name = "Newborn"},
                new Category() {Name = "1 Month Old"},
            };
            
            for (int i = 2; i < 25; i++)
            {
                categories.Add(new Category() { Name = i + " Months Old" });
            }

            context.Categories.AddOrUpdate(categories.ToArray());
            context.SaveChanges();
        }

        private void SeedTopics(BabyDevDbContext context)
        {
            var categoryId = context.Categories.FirstOrDefault(c => c.Name == "Newborn").Id;
            var authorId = context.Users.FirstOrDefault(a => a.Email == "user@babydev.com").Id;
            var topic = new Topic() { Title = "Your newborn", AuthorId = authorId, CategoryId = categoryId, RelatedMonths = 0, CreatedOn = DateTime.Now };
            context.Topics.Add(topic);
            context.SaveChanges();
        }

        private void SeedParagraphs(BabyDevDbContext context)
        {
            var topicId = context.Topics.FirstOrDefault(t => t.Title == "Your newborn").Id;
            var paragraph = new List<Paragraph>()
                {
                    new Paragraph()
                    {
                        Subtitle = "How your baby's growing:",
                        Content =
                            "Because he was curled up inside your uterus until recently, your newborn baby will probably look scrunched up for a while, with his arms and legs not fully extended. He may even appear bowlegged. Don't worry: Your baby will stretch out, little by little, and by the time he reaches 6 months, he'll be fully unfurled! In the meantime, as he adjusts to life outside the warm, safe confines of your womb, he may enjoy being swaddled in a light blanket.",
                        TopicId = topicId
                    },
                    new Paragraph()
                    {
                        Subtitle = "Your life: You're a parent!",
                        Content =
                            "This week, reality sets in — you have a baby! He's all yours, he's home with you, and he's dependent on you for love, care, and feeding. No doubt you've been reading up on what to do and how to do it. We have plenty of articles and tools to refresh your memory and teach you new tips, but here's our best advice this week: Don't try to master the art of caring for a baby all at once. Take it easy, take it slow. Your newborn is more durable than you might think. He's getting used to you as much as you and your partner are getting used to him. Like all good relationships, this one will take some time.",
                        TopicId = topicId
                    },
                };

            context.Paragraphs.AddOrUpdate(paragraph.ToArray());
            context.SaveChanges();
        }
    }
}
