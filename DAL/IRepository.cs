using BLL.Search;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepository<TEntity, TSearchCriteria, TSearchResult, TContext>
        where TEntity : class
        where TSearchCriteria : SearchCriteria
        where TSearchResult : GenericSearchResult<TEntity>, new()
        where TContext : DbContext
    {
        TSearchResult Search(TSearchCriteria criteria);
        IEnumerable<TEntity> SearchAll(TSearchCriteria criteria);
        Task InsertMany(IList<TEntity> entities);
        Task Insert(TEntity entity);
        Task Update(int id, TEntity newEntity);
    }
}
