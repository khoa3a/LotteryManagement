using BLL.Entities;
using System.Data.Entity;

namespace BLL
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

        public virtual DbSet<NorthMondayEntity> NorthMondayEntities { get; set; }
        public virtual DbSet<NorthTuesdayEntity> NorthTuesdayEntities { get; set; }
        public virtual DbSet<NorthWednesdayEntity> NorthWednesdayEntities { get; set; }
        public virtual DbSet<NorthThursdayEntity> NorthThursdayEntities { get; set; }
    }
}
