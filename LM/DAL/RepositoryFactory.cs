namespace LM.DAL
{
    internal class RepositoryFactory
    {
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
