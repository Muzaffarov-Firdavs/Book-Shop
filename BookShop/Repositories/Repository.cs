using BookShop.DbContexts;
using BookShop.Domain.Commons;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly AppDbContext dbContext;

        private readonly DbSet<TEntity> dbSet;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }


        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var model = await this.dbSet.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
            return model.Entity;
        }

        public async Task<IQueryable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression is null) return dbSet;

            return this.dbSet.Where(expression);
        }

        public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.dbSet.Where(expression).FirstOrDefaultAsync();
        }
    }
}
