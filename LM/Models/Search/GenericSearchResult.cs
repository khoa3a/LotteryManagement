namespace LM.Models.Search
{
    public class GenericSearchResult<T>
    {
        public GenericSearchResult()
        {
            Results = [];
        }
        public int TotalCount { get; set; }
        public IList<T> Results { get; set; }
    }
}
