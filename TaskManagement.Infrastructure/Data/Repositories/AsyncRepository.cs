using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Shared.Enums;
using TaskManagement.Domain.Shared.Repositories;

namespace TaskManagement.Infrastructure.Data.Repositories
{
    public class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private readonly ISpecificationEvaluator _specificationEvaluator;

        public AsyncRepository(ApplicationDbContext dbContext)
             : this(dbContext, SpecificationEvaluator.Default)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="specificationEvaluator"></param>
        public AsyncRepository(ApplicationDbContext dbContext,
             ISpecificationEvaluator specificationEvaluator)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _specificationEvaluator = specificationEvaluator;
        }

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync(new CancellationToken());
        }

        /// <summary>
        /// ClearTracker
        /// </summary>
        public void ClearTracker()
        {
            _dbContext.ChangeTracker.Clear();
        } 

        /// <summary>
        /// GetListAsync
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <param name="orderBy"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> filter,
            string includeProperties = "",
            Expression<Func<TEntity, object>>? orderBy = null,
            SortTypes? sortType = SortTypes.Ascending)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            //ApplyFilter
            if(filter != null)
            {
                query = query.Where(filter);
            }
            //Apply sorting
            if(orderBy != null)
            {
                query = sortType == SortTypes.Descending
                    ? query.OrderByDescending(orderBy)
                    : query.OrderBy(orderBy);
            }
            // Apply eager loading to related entities
            foreach(var includeProperty in  includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync(new CancellationToken());

        }

        /// <summary>
        /// GetSingleAsync
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetEntityAsync(Expression<Func<TEntity, bool>>? filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            // Apply filter
            if(filter != null)
            {
                query = query.Where(filter);
            }
            // Apply eager loading to related entities
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(new CancellationToken());
        }



    }
}
