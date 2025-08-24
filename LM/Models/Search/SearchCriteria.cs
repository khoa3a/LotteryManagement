namespace LM.Models.Search
{
    public class SearchCriteria
    {
        public virtual int Skip { get; set; } = 0;
        public virtual int Take { get; set; } = 20;
        public virtual IList<SortInfor> Sortings { get; set; } = [];
    }

    public class SortInfor
    {
        public string FieldName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
