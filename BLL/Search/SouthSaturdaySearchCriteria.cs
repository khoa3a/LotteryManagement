namespace BLL.Search
{
    public class SouthSaturdaySearchCriteria : SearchCriteria
    {
        public List<int?> Subs { get; set; }

        public DateTime? From { get; set; } = null;
    }
}
