using System.Linq.Expressions;
using Core.Persistance.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistance.Repositories;

public interface IAsyncRepository<TEntity,TEntityId>
where TEntity : Entity<TEntityId>
{
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity, object>>? include=null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
        );

    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
        );

    Task<Paginate<TEntity>> GetListByDynamicAsync(
        DynamicQuery dynamic,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    
    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<TEntity> AddAsync(TEntity entity);
    
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entity);
    
    Task<TEntity> UpdateAsync(TEntity entity);
    
    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entity);
    
    Task<TEntity> DeleteAsync(TEntity entity, bool permenant = false);
    
    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entity, bool permenant = false);
}