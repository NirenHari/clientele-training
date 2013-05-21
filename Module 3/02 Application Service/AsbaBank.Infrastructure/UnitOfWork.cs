using System.Data.Entity;
using AsbaBank.Infrastructure;

namespace AsbaBank.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext Context;

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new SqlRepository<TEntity>(Context);
        }
    }
}