namespace DAL
{
    public class RepositoryFactory
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

        public static SouthThursdayRepository GetSouthThursdayRepo()
        {
            return new SouthThursdayRepository();
        }

        public static SouthFridayRepository GetSouthFridayRepo()
        {
            return new SouthFridayRepository();
        }

        public static SouthSaturdayRepository GetSouthSaturdayRepo()
        {
            return new SouthSaturdayRepository();
        }

        public static SouthSundayRepository GetSouthSundayRepo()
        {
            return new SouthSundayRepository();
        }

        public static NorthRepository GetNorthRepo()
        {
            return new NorthRepository();
        }

        public static NorthMondayRepository GetNorthMondayRepo()
        {
            return new NorthMondayRepository();
        }

        public static NorthTuesdayRepository GetNorthTuesdayRepo()
        {
            return new NorthTuesdayRepository();
        }

        public static NorthWednesdayRepository GetNorthWednesdayRepo()
        {
            return new NorthWednesdayRepository();
        }

        public static NorthThursdayRepository GetNorthThursdayRepo()
        {
            return new NorthThursdayRepository();
        }
    }
}
