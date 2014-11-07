namespace BabyDev.Data.Contracts
{
    using BabyDev.Data.Repositories;
    using BabyDev.Models;

    public interface IBabyDevData
    {
        IRepository<Answer> Answers { get; }

        IRepository<Category> Categories { get; }

        IRepository<Child> Children { get; }

        IRepository<Paragraph> Paragraphs { get; }

        IRepository<Question> Questions { get; }

        IRepository<Topic> Topics { get; }

        IRepository<BabyDevUser> Users { get; }

        int SaveChanges();
    }
}
