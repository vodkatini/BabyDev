using BabyDev.Contracts;

namespace BabyDev.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using BabyDev.Data.Contracts;
    using BabyDev.Models;
    using BabyDev.Data.Repositories;

    public class BabyDevData : IBabyDevData
    {
        private IBabyDevDbContext context;
        private IDictionary<Type, object> repositories;

        public BabyDevData(IBabyDevDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IBabyDevDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IDeletableEntityRepository<Answer> Answers
        {
            get
            {
                return this.GetDeletableEntityRepository<Answer>();
            }
        }

        public IDeletableEntityRepository<Category> Categories
        {
            get
            {
                return this.GetDeletableEntityRepository<Category>();
            }
        }

        public IDeletableEntityRepository<Child> Children
        {
            get
            {
                return this.GetDeletableEntityRepository<Child>();
            }
        }

        public IDeletableEntityRepository<Paragraph> Paragraphs
        {
            get
            {
                return this.GetDeletableEntityRepository<Paragraph>();
            }
        }

        public IDeletableEntityRepository<Question> Questions
        {
            get
            {
                return this.GetDeletableEntityRepository<Question>();
            }
        }

        public IDeletableEntityRepository<Topic> Topics
        {
            get
            {
                return this.GetDeletableEntityRepository<Topic>();
            }
        }

        public IRepository<BabyDevUser> Users
        {
            get
            {
                return this.GetRepository<BabyDevUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
