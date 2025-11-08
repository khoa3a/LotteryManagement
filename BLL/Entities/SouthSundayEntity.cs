using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    [Table("SouthSunday")]
    public partial class SouthSundayEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Number { get; set; }
        public string Sub2Number { get; set; }
        public string Sub3Number { get; set; }
        public string Sub4Number { get; set; }
        public int? Sub1 { get; set; }
        public int? Sub2 { get; set; }
        public int Sub3 { get; set; }
        public int Sub4 { get; set; }
    }
}
