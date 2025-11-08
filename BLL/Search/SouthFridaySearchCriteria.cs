namespace BLL.Search
{
    public class SouthFridaySearchCriteria : SearchCriteria
    {
        public List<int?> Subs { get; set; }

        public DateTime? From { get; set; } = null;
    }
}
