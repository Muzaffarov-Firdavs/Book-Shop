using BookShop.Domain.Commons;
using System.Linq.Expressions;

namespace BookShop.Repositories
{
    public interface IRepository<TEntity> where TEntity : Auditable
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression);
        Task<IQueryable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> expression = null);
    }
}
