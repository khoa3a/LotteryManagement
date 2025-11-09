using BLL.Entities;
using BLL.Search;
using BLL;
using Common;
using Common.Utils;

namespace DAL
{
    public class SouthMondayRepository : BaseRepository<SouthMondayEntity, SouthMondaySearchCriteria, SouthMondaySearchResult, LotteryManagementEntities>
    {
        protected override IQueryable<SouthMondayEntity> BuildQuery(SouthMondaySearchCriteria criteria)
        {
            _baseQuery = _dbContext.Set<SouthMondayEntity>().AsNoTracking();

            if (criteria.Subs.SafeAny())
            {
                _baseQuery = _baseQuery.Where(x => x.Sub4Number != null);

                var count = criteria.Subs.Count();
                if (count == 4)
                {
                    _baseQuery = _baseQuery.Where(x => criteria.Subs.Contains(x.Sub1) &&
                                                   criteria.Subs.Contains(x.Sub2) &&
                                                   criteria.Subs.Contains(x.Sub3) &&
                                                   criteria.Subs.Contains(x.Sub4));
                }
                else if (count == 3)
                {
                    _baseQuery = _baseQuery.Where(x =>
                                (criteria.Subs.Contains(x.Sub1) && criteria.Subs.Contains(x.Sub2) && criteria.Subs.Contains(x.Sub3)) ||
                                (criteria.Subs.Contains(x.Sub2) && criteria.Subs.Contains(x.Sub3) && criteria.Subs.Contains(x.Sub4)) ||
                                (criteria.Subs.Contains(x.Sub3) && criteria.Subs.Contains(x.Sub4) && criteria.Subs.Contains(x.Sub1)) ||
                                (criteria.Subs.Contains(x.Sub4) && criteria.Subs.Contains(x.Sub1) && criteria.Subs.Contains(x.Sub2)));
                }
                else if (count == 2)
                {
                    _baseQuery = _baseQuery.Where(x =>
                                (criteria.Subs.Contains(x.Sub3) && criteria.Subs.Contains(x.Sub4)) ||
                                (criteria.Subs.Contains(x.Sub4) && criteria.Subs.Contains(x.Sub3)));
                }
            }

            if (criteria.From.HasValue)
            {
                var fromDate = AppUtils.RefineSearchDate(criteria.From.Value, true);

                _baseQuery = _baseQuery.Where(x => x.Date > fromDate);

                var toDate = DateTime.Now;

                _baseQuery = _baseQuery.Where(x => x.Date < toDate);
            }

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
