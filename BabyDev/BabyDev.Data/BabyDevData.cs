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
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public BabyDevData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Answer> Answers
        {
            get
            {
                return this.GetRepository<Answer>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Child> Children
        {
            get
            {
                return this.GetRepository<Child>();
            }
        }

        public IRepository<Paragraph> Paragraphs
        {
            get
            {
                return this.GetRepository<Paragraph>();
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                return this.GetRepository<Question>();
            }
        }

        public IRepository<Topic> Topics
        {
            get
            {
                return this.GetRepository<Topic>();
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

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
