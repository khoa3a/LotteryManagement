using LM.Models.Entities;
using System.Data.Entity;

namespace LM.Models
{
    public partial class LotteryManagementEntities : DbContext
    {
        public LotteryManagementEntities() : base("name=LotteryManagementEntities")
        {
        }

        public virtual DbSet<SouthFridayEntity> SouthFridayEntities { get; set; }
        public virtual DbSet<SouthSaturdayEntity> SouthSaturdayEntities { get; set; }
    }
}
