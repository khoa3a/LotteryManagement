using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    [Table("SouthThursday")]
    public partial class SouthThursdayEntity
    {
        public int Id { get; set; }
        public string DateKey { get; set; }
        public string Number { get; set; }
        public string SubNumber { get; set; }
        public string Name { get; set; }
    }
}
