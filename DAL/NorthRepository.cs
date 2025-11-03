using BLL.Entities;
using BLL.Search;
using BLL;
using Common;

namespace DAL
{
    public class NorthRepository : BaseRepository<NorthEntity, NorthSearchCriteria, NorthSearchResult, LotteryManagementEntities>
    {
        protected override IQueryable<NorthEntity> BuildQuery(NorthSearchCriteria criteria)
        {
            _baseQuery = _dbContext.Set<NorthEntity>().AsNoTracking();

            _baseQuery = _baseQuery.Where(x => x.Sub4Number != null);

            if (criteria.Subs.SafeAny())
            {
                _baseQuery = _baseQuery.Where(x => criteria.Subs.Contains(x.Sub1) &&
                                                   criteria.Subs.Contains(x.Sub2) &&
                                                   criteria.Subs.Contains(x.Sub3) &&
                                                   criteria.Subs.Contains(x.Sub4));
            }

            return _baseQuery;
        }

        protected override IQueryable<NorthEntity> BuildSort(IQueryable<NorthEntity> query, NorthSearchCriteria criteria)
        {
            if (criteria.Sortings.SafeAny())
            {
                foreach (var sorting in criteria.Sortings)
                {
                    if (!string.IsNullOrEmpty(sorting.FieldName) && !string.IsNullOrEmpty(sorting.Type))
                    {
                        switch (sorting.FieldName)
                        {
                            case "DepartureDate":
                                //query = sorting.Type == "asc" ? query.OrderBy(x => x.DepartureDate) : query.OrderByDescending(x => x.DepartureDate);
                                break;
                            case "BusStyle":
                                //query = sorting.Type == "asc" ? query.OrderBy(x => x.BusStyle) : query.OrderByDescending(x => x.BusStyle);
                                break;
                        }
                    }
                }

                return query;
            }

            return query.OrderBy(x => x.Id);
        }
    }
}
