using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    [Table("North")]
    public class NorthEntity
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
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Sub3 { get; set; }
        public string Sub4 { get; set; }        
    }
}
