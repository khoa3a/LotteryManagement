namespace BLL.Search
{
    public class SouthWednesdaySearchCriteria : SearchCriteria
    {
        public List<int?> Subs { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? From { get; set; } = null;
    }
}
