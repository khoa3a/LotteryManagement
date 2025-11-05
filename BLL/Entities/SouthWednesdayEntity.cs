using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    [Table("SouthWednesday")]
    public partial class SouthWednesdayEntity
    {
        public int Id { get; set; }
        public string DateKey { get; set; }
        public string Number { get; set; }
        public string Sub2Number { get; set; }
        public string Sub3Number { get; set; }
        public string Sub4Number { get; set; }
        public int? Sub1 { get; set; }
        public int? Sub2 { get; set; }
        public int Sub3 { get; set; }
        public int Sub4 { get; set; }
        public string Name { get; set; }
    }
}
