using LM.Utils;
using LM.Models.Search;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace LM.DAL
{
    abstract class BaseRepository<TEntity, TSearchCriteria, TSearchResult, TContext> : IRepository<TEntity, TSearchCriteria, TSearchResult, TContext>, IDisposable
        where TEntity : class
        where TSearchCriteria : SearchCriteria
        where TSearchResult : GenericSearchResult<TEntity>, new()
        where TContext : DbContext, new()
    {
        protected DbContext _dbContext;
        protected IQueryable<TEntity> _baseQuery;

        protected BaseRepository()
        {
            _dbContext = new TContext();
            _dbContext.Configuration.ProxyCreationEnabled = false;
            _dbContext.Database.CommandTimeout = 180;
            _baseQuery = _dbContext.Set<TEntity>().AsNoTracking();
        }

        protected abstract IQueryable<TEntity> BuildQuery(TSearchCriteria criteria);
        protected abstract IQueryable<TEntity> BuildSort(IQueryable<TEntity> query, TSearchCriteria criteria);

        public virtual async Task<int> Count(TSearchCriteria criteria)
        {
            var query = BuildQuery(criteria);

            return await query.CountAsync();
        }

        public virtual TSearchResult Search(TSearchCriteria criteria)
        {
            var result = new TSearchResult();

            var query = BuildQuery(criteria);

            result.TotalCount = query.Count();

            if (criteria.Take > 0)
            {
                query = BuildSort(query, criteria);

                var items = query
                    .Skip(criteria.Skip)
                    .Take(criteria.Take)
                    .ToList();

                result.Results = items;
            }

            return result;
        }

        public virtual IEnumerable<TEntity> SearchAll(TSearchCriteria criteria)
        {
            int count = 0;
            int totalCount;

            criteria.Take = 20;
            do
            {
                criteria.Skip = count;

                var models = Search(criteria);
                totalCount = models.TotalCount;

                count += models.Results.Count();

                foreach (var model in models.Results)
                {
                    yield return model;
                }
            }
            while (count < totalCount);
        }

        public async Task InsertMany(IList<TEntity> entities)
        {
            try
            {
                _dbContext.Set<TEntity>().AddRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                AppUtils.WriteLog(ex);
            }
        }

        public async Task Insert(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                AppUtils.WriteLog(ex);
            }
        }

        public async Task Update(int id, TEntity newEntity)
        {
            try
            {
                if (newEntity != null)
                {
                    var existing = _dbContext.Set<TEntity>().Find(id);
                    if (existing != null)
                    {
                        _dbContext.Entry(existing).CurrentValues.SetValues(newEntity);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLog(ex);
            }
        }

        public async Task Delete(TSearchCriteria criteria)
        {
            try
            {
                var entities = SearchAll(criteria);

                foreach (var entity in entities)
                {
                    _dbContext.Set<TEntity>().Attach(entity);
                    _dbContext.Set<TEntity>().Remove(entity);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLog(ex);
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
