using BLL.Entities;
using BLL.Search;
using BLL;
using Common;

namespace DAL
{
    public class SouthMondayRepository : BaseRepository<SouthMondayEntity, SouthMondaySearchCriteria, SouthMondaySearchResult, LotteryManagementEntities>
    {
        protected override IQueryable<SouthMondayEntity> BuildQuery(SouthMondaySearchCriteria criteria)
        {
            _baseQuery = _dbContext.Set<SouthMondayEntity>().AsNoTracking();

            if (!string.IsNullOrEmpty(criteria.DateKey))
            {
                _baseQuery = _baseQuery.Where(x => x.DateKey == criteria.DateKey);
            }

            //if (criteria.DayOfWeek != null)
            //{
            //    _baseQuery = _baseQuery.Where(x => x.DayOfWeek == criteria.DayOfWeek.Value);
            //}

            return _baseQuery;
        }

        protected override IQueryable<SouthMondayEntity> BuildSort(IQueryable<SouthMondayEntity> query, SouthMondaySearchCriteria criteria)
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
