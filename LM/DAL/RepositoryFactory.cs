namespace LM.DAL
{
    internal class RepositoryFactory
    {
        public static SouthMondayRepository GetSouthMondayRepo()
        {
            return new SouthMondayRepository();
        }

        public static SouthTuesdayRepository GetSouthTuesdayRepo()
        {
            return new SouthTuesdayRepository();
        }

        public static SouthWednesdayRepository GetSouthWednesdayRepo()
        {
            return new SouthWednesdayRepository();
        }

        public static SouthFridayRepository GetSouthFridayRepo()
        {
            return new SouthFridayRepository();
        }

        public static SouthSaturdayRepository GetSouthSaturdayRepo()
        {
            return new SouthSaturdayRepository();
        }
    }
}
