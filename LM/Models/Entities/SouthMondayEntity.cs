using System.ComponentModel.DataAnnotations.Schema;

namespace LM.Models.Entities
{
    [Table("SouthMonday")]
    public partial class SouthMondayEntity
    {
        public int Id { get; set; }
        public string DateKey { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
    }
}
