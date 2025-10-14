using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    [Table("SouthSaturday")]
    public partial class SouthSaturdayEntity
    {
        public int Id { get; set; }
        public string DateKey { get; set; }
        public string Number { get; set; }
        public string SubNumber { get; set; }
        public string Sub0 { get; set; }
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Name { get; set; }
    }
}
