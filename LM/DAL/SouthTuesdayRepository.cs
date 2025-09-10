using LM.Models.Entities;
using LM.Models.Search;
using LM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.DAL
{    
    class SouthTuesdayRepository : BaseRepository<SouthTuesdayEntity, SouthTuesdaySearchCriteria, SouthTuesdaySearchResult, LotteryManagementEntities>
    {
        protected override IQueryable<SouthTuesdayEntity> BuildQuery(SouthTuesdaySearchCriteria criteria)
        {
            _baseQuery = _dbContext.Set<SouthTuesdayEntity>().AsNoTracking();

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

        protected override IQueryable<SouthTuesdayEntity> BuildSort(IQueryable<SouthTuesdayEntity> query, SouthTuesdaySearchCriteria criteria)
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
