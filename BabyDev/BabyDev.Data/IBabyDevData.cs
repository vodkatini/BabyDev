namespace BabyDev.Data
{
    using BabyDev.Data.Repositories;
    using BabyDev.Models;

    public interface IBabyDevData
    {
        IRepository<BabyDevUser> Users { get; }

        int SaveChanges();
    }
}
