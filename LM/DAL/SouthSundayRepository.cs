using LM.Models.Entities;
using LM.Models.Search;
using LM.Models;
namespace LM.DAL
{    
    class SouthSundayRepository : BaseRepository<SouthSundayEntity, SouthSundaySearchCriteria, SouthSundaySearchResult, LotteryManagementEntities>
    {
        protected override IQueryable<SouthSundayEntity> BuildQuery(SouthSundaySearchCriteria criteria)
        {
            _baseQuery = _dbContext.Set<SouthSundayEntity>().AsNoTracking();

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

        protected override IQueryable<SouthSundayEntity> BuildSort(IQueryable<SouthSundayEntity> query, SouthSundaySearchCriteria criteria)
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
