using System.Data.Entity.Infrastructure;

namespace BabyDev.Data.Contracts
{
    using System.Data.Entity;

    using BabyDev.Models;

    public interface IBabyDevDbContext
    {
        IDbSet<Answer> Answers { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Child> Children { get; set; }

        IDbSet<Paragraph> Paragraphs { get; set; }

        IDbSet<Question> Questions { get; set; }

        IDbSet<Topic> Topics { get; set; }

        IDbSet<BabyDevUser> Users { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
