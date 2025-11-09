namespace BLL.Search
{
    public class SouthMondaySearchCriteria : SearchCriteria
    {
        public List<int?> Subs { get; set; }

        public DateTime? From { get; set; } = null;
    }
}
