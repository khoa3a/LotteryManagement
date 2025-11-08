namespace BLL.Search
{
    public class SouthSundaySearchCriteria : SearchCriteria
    {
        public List<int?> Subs { get; set; }

        public DateTime? From { get; set; } = null;
    }
}
