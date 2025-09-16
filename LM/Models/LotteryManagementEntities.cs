using LM.Models.Entities;
using System.Data.Entity;

namespace LM.Models
{
    public partial class LotteryManagementEntities : DbContext
    {
        public LotteryManagementEntities() : base("name=LotteryManagementEntities")
        {
        }

        public virtual DbSet<SouthMondayEntity> SouthMondayEntities { get; set; }
        public virtual DbSet<SouthTuesdayEntity> SouthTuesdayEntities { get; set; }
        public virtual DbSet<SouthWednesdayEntity> SouthWednesdayEntities { get; set; }
        public virtual DbSet<SouthThursdayEntity> SouthThursdayEntities { get; set; }
        public virtual DbSet<SouthFridayEntity> SouthFridayEntities { get; set; }
        public virtual DbSet<SouthSaturdayEntity> SouthSaturdayEntities { get; set; }
        public virtual DbSet<SouthSundayEntity> SouthSundayEntities { get; set; }
    }
}
