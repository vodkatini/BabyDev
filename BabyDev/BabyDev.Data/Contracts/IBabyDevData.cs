
namespace BabyDev.Data.Contracts
{
    using BabyDev.Contracts;
    using BabyDev.Models;

    public interface IBabyDevData
    {
        IBabyDevDbContext Context { get; }

        IDeletableEntityRepository<Answer> Answers { get; }

        IDeletableEntityRepository<Category> Categories { get; }

        IDeletableEntityRepository<Child> Children { get; }

        IDeletableEntityRepository<Paragraph> Paragraphs { get; }

        IDeletableEntityRepository<Question> Questions { get; }

        IDeletableEntityRepository<Topic> Topics { get; }

        IRepository<BabyDevUser> Users { get; }

        int SaveChanges();
    }
}
