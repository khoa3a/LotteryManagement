namespace BLL.Search
{
    public class SouthThursdaySearchCriteria : SearchCriteria
    {
        public List<int?> Subs { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? From { get; set; } = null;
    }
}
