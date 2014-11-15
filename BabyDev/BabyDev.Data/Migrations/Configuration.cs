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
            if (!context.Users.Any())
            {
                SeedUsers(context);
                SeedCategories(context);
                SeedTopics(context);
                SeedParagraphs(context);
                SeedQuestions(context);
            }
        }        

        private void SeedUsers(BabyDevDbContext context)
        {
            var store = new UserStore<BabyDevUser>(context);
            var manager = new UserManager<BabyDevUser>(store);
            var admin = new BabyDevUser { UserName = "admin@babydev.com", Email = "admin@babydev.com" };
            var expert = new BabyDevUser { UserName = "expert@babydev.com", Email = "expert@babydev.com" };
            var user = new BabyDevUser { UserName = "user@babydev.com", Email = "user@babydev.com" };
            context.Roles.Add(new IdentityRole { Name = "Admin" });
            context.Roles.Add(new IdentityRole { Name = "Expert" });
            context.SaveChanges();

            manager.Create(user, "123456");
            manager.Create(admin, "123456");
            manager.Create(expert, "123456");
            manager.AddToRole(admin.Id, "Admin");
            manager.AddToRole(admin.Id, "Expert");
            manager.AddToRole(expert.Id, "Expert");
            context.SaveChanges();
        }

        private void SeedCategories(BabyDevDbContext context)
        {
            var categories = new List<Category>()
            {
                new Category() {Name = "Pregnancy"},
                new Category() {Name = "Newborn"},
                new Category() {Name = "Baby"},
                new Category() {Name = "Toddler"},
                new Category() {Name = "Preschooler"},
                new Category() {Name = "Big Kid"},
                new Category() {Name = "For You"},
                new Category() {Name = "Breastfeeding"},
                new Category() {Name = "Attached Parenting"}
            };

            context.Categories.AddOrUpdate(categories.ToArray());
            context.SaveChanges();
        }

        private void SeedTopics(BabyDevDbContext context)
        {
            var newbornId = context.Categories.FirstOrDefault(c => c.Name == "Newborn").Id;
            var pregnancyId = context.Categories.FirstOrDefault(c => c.Name == "Pregnancy").Id;
            var authorId = context.Users.FirstOrDefault(a => a.Email == "expert@babydev.com").Id;
            var topics = new List<Topic>()
            { 
                new Topic() 
                { 
                Title = "Your newborn", 
                AuthorId = authorId, 
                CategoryId = newbornId, 
                RelatedMonths = 0, 
                CreatedOn = DateTime.Now 
                },
                new Topic() 
                { 
                Title = "First trimester", 
                AuthorId = authorId, 
                CategoryId = pregnancyId, 
                RelatedMonths = 0, 
                CreatedOn = DateTime.Now 
                },
                new Topic() 
                { 
                Title = "How to get pregnant", 
                AuthorId = authorId, 
                CategoryId = pregnancyId, 
                RelatedMonths = 0, 
                CreatedOn = DateTime.Now 
                },
                new Topic() 
                { 
                Title = "Your one month old", 
                AuthorId = authorId, 
                CategoryId = newbornId, 
                RelatedMonths = 0, 
                CreatedOn = DateTime.Now 
                },
                new Topic() 
                { 
                Title = "Your one week old", 
                AuthorId = authorId, 
                CategoryId = newbornId, 
                RelatedMonths = 0, 
                CreatedOn = DateTime.Now 
                },
            };

            foreach (var topic in topics)
            {
                context.Topics.Add(topic);
            }
            context.SaveChanges();
        }

        private void SeedParagraphs(BabyDevDbContext context)
        {
            var newbornId = context.Topics.FirstOrDefault(t => t.Title == "Your newborn").Id;
            var firstTrimesterId = context.Topics.FirstOrDefault(t => t.Title == "First trimester").Id;
            var howToGetPreg = context.Topics.FirstOrDefault(t => t.Title == "How to get pregnant").Id;
            var oneMonthOld = context.Topics.FirstOrDefault(t => t.Title == "Your one month old").Id;
            var oneWeekOld = context.Topics.FirstOrDefault(t => t.Title == "Your one week old").Id;
            var authorId = context.Users.FirstOrDefault(a => a.Email == "expert@babydev.com").Id;
            var paragraphs = new List<Paragraph>()
                {
                    new Paragraph()
                    {
                        Subtitle = "How your baby's growing:",
                        Content =
                            "Because he was curled up inside your uterus until recently, your newborn baby will probably look scrunched up for a while, with his arms and legs not fully extended. He may even appear bowlegged. Don't worry: Your baby will stretch out, little by little, and by the time he reaches 6 months, he'll be fully unfurled! In the meantime, as he adjusts to life outside the warm, safe confines of your womb, he may enjoy being swaddled in a light blanket.",
                        TopicId = newbornId,
                        AuthorId = authorId
                    },
                    new Paragraph()
                    {
                        Subtitle = "Your life: You're a parent!",
                        Content =
                            "This week, reality sets in — you have a baby! He's all yours, he's home with you, and he's dependent on you for love, care, and feeding. No doubt you've been reading up on what to do and how to do it. We have plenty of articles and tools to refresh your memory and teach you new tips, but here's our best advice this week: Don't try to master the art of caring for a baby all at once. Take it easy, take it slow. Your newborn is more durable than you might think. He's getting used to you as much as you and your partner are getting used to him. Like all good relationships, this one will take some time.",
                        TopicId = newbornId,
                        AuthorId = authorId
                    },
                    new Paragraph()
                    {
                        Subtitle = "How age affects pregnancy rates",
                        Content =
                            "The older you get, the longer it may take you to get pregnant. That’s primarily because your eggs tend to decrease in quality as they age. (They've been with you since you were born.) That means fewer of them are able to join with a sperm and grow into a healthy baby. Interestingly, male fertility rates don’t appear to start to decline until around age 50. After one year of trying, about 86 percent of healthy, fertile women in their early 20s will get pregnant. The rate drops to about 63 percent among healthy, fertile women in their early 30s, and 36 percent among healthy, fertile women in their early 40s. By age 45, close to 0 percent of women are able to get pregnant naturally.",
                        TopicId = howToGetPreg,
                        AuthorId = authorId
                    },new Paragraph()
                    {
                        Subtitle = "What your baby looks like",
                        Content =
                            "After fertilization and implantation, your baby grows quickly. At first she's just an embryo, consisting of two layers of cells from which all her organs and body parts will develop. Soon she's about the size of a kidney bean and constantly moving. Her heart is beating quickly and her intestines are forming. Her earlobes, eyelids, mouth, and nose are also taking shape.",
                        TopicId = firstTrimesterId,
                        AuthorId = authorId
                    },new Paragraph()
                    {
                        Subtitle = "How your baby's growing:",
                        Content =
                            "Your baby's eyesight is still pretty fuzzy. Babies are born nearsighted and can see things best when they're about 8 to 15 inches away, so she can see your face clearly only when you're holding her close. Don't worry if your baby doesn't look you right in the eye from the start: Newborns tend to look at your eyebrows, your hairline, or your moving mouth. As she gets to know you in the first month, she'll become more interested in having eye-to-eye exchanges. Studies show that newborns prefer human faces to all other patterns or colors. (Objects that are bright, moving, high-contrast, or black-and-white are next in line.)",
                        TopicId = oneWeekOld,
                        AuthorId = authorId
                    },new Paragraph()
                    {
                        Subtitle = "Your life: Mixed feelings",
                        Content =
                            "Even when you're the happiest person on earth to be a new parent, it's common to have nagging little feelings of disappointment. Not that you want to tell anyone. But you spent nine months imagining what your baby would be like and now here he is — perhaps not exactly what you'd pictured. Parents of a baby born with a health problem are especially vulnerable to this feeling of not getting what they'd bargained for. But parents of healthy children often have such feelings too.",
                        TopicId = oneMonthOld,
                        AuthorId = authorId
                    },
                };

            foreach (var paragraph in paragraphs)
            {
                context.Paragraphs.Add(paragraph);
            }

            context.SaveChanges();
        }

        private void SeedQuestions(BabyDevDbContext context)
        {
            var authorId = context.Users.FirstOrDefault(a => a.Email == "user@babydev.com").Id;
            var question = new Question()
            {
                Title = "My baby is not eating",
                Body = "She is 6 months old now and I started giving her real food, but she refuses to eat it. What to do?",
                AuthorId = authorId,
                CreatedOn = DateTime.Now
            };

            context.Questions.Add(question);
            context.SaveChanges();
        }
    }
}
