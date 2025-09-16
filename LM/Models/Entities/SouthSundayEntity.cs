using System.ComponentModel.DataAnnotations.Schema;

namespace LM.Models.Entities
{
    [Table("SouthSunday")]
    public partial class SouthSundayEntity
    {
        public int Id { get; set; }
        public string DateKey { get; set; }
        public string Number { get; set; }
        public string SubNumber { get; set; }
        public string Name { get; set; }
    }
}
