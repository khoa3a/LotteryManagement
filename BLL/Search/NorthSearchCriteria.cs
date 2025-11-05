namespace BLL.Search
{
    public class NorthSearchCriteria : SearchCriteria
    {
        public List<int?> Subs { get; set; }

        public DateTime? From { get; set; } = null;
    }
}
