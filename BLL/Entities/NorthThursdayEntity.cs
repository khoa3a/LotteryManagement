using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    [Table("NorthThursday")]
    public class NorthThursdayEntity
    {
        public int Id { get; set; }
        public string DateKey { get; set; }
        public string Number { get; set; }
        public string Sub2Number { get; set; }
        public string Sub3Number { get; set; }
        public string Sub4Number { get; set; }
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Sub3 { get; set; }
        public string Sub4 { get; set; }
        public string Name { get; set; }
    }
}
