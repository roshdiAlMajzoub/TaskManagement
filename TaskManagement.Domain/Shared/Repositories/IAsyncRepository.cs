using Ardalis.Specification;
using System.Linq;
using System.Linq.Expressions;
using TaskManagement.Domain.Shared.Enums;

namespace TaskManagement.Domain.Shared.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        void ClearTracker();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity?> GetByIdAsync(object id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <param name="orderBy"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter, string includeProperties = "", Expression<Func<TEntity, object>>? orderBy = null, SortTypes? sortType = SortTypes.Ascending);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>>? filter = null, string includeProperties = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <param name="orderBy"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        Task<(IEnumerable<TEntity> Data, int TotalCount, int PageNumber, int PageSize)> GetListPaginatedAsync(
            int pageNumber = 1,
            int pageSize = 10,
            Expression<Func<TEntity, bool>>? filter = null,
            string includeProperties = "",
            Expression<Func<TEntity, object>>? orderBy = null,
            SortTypes? sortType = SortTypes.Ascending);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <param name="orderBy"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        Task<(IEnumerable<TEntity> Data, int TotalCount, int PageNumber, int PageSize)> GetListPaginatedWithNestedSortAsync(
            int pageNumber = 1,
            int pageSize = 10,
            Expression<Func<TEntity, bool>>? filter = null,
            string includeProperties = "",
            Expression<Func<TEntity, object>>? orderBy = null,
            SortTypes? sortType = SortTypes.Ascending);

        /// <summary>
        /// Finds all entities of <typeparamref name="TEntity" />, that matches the encapsulated query logic of the
        /// <paramref name="specification"/>, from the database.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{T}" /> that contains elements from the input sequence.
        /// </returns>
        IQueryable<TEntity> GetQueryable(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryable(CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> GetFilteredCountAsync(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAndReturnAsync(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddRangeAsync(List<TEntity> entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Attach(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetListWithSpecAsync(ISpecification<TEntity> specification,
            CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity?> GetSingleWithSpecAsync(ISpecification<TEntity> specification,
                    CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetCountWithSpecAsync(ISpecification<TEntity> specification,
                  CancellationToken cancellationToken = default);

    }
}
