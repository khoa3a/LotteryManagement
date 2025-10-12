namespace Common
{
    public static class AppConstants
    {
        public const short DefaultSleepTime = 2000; // Two seconds
        public const short DefaultTryAttempts = 5; // Five times
        public const short DefaultBufferMinutes = 1; // One minute
        public const short DefaultBufferDays = 1; // One day
        public const short DefaultCleanUpMonths = 3; // 3 months
        public const short DefaultBatchSize = 20;
        public const int CID_CititransId = 7079;
        public const string JsonContentType = "application/json";
        public const string FormContentType = "application/x-www-form-urlencoded"; 
        public const string DefaultDateTimeFormat = "yyyyMMddHHmmss";
        public const string DefaultDateFormat = "yyyy-MM-dd";
        public const string DefaultCurrency = "Rp";
        public const string ApiPointSearchAll = "vendor/v2/points";
        public const string ApiTripSearchAll = "vendor/v2/manifest/";
        public const string ApiGetSeatAvailable = "vendor/v2/manifest/picker/";
        public const string ApiResponseSuccess = "0";
        public const string ExDetailPackage = "DetailPackage is null";
        public const string ExUnitDetail = "UnitDetail is null";
        public const string Executive = "Executive";
    }
}