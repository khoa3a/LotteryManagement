using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace LM.Utils
{
    public static class AppUtils
    {
        public static void WriteLog(Exception ex)
        {
            using (StreamWriter w = File.AppendText("logs.txt"))
            {
                w.WriteLine(ex.Message);
                w.WriteLine(ex.ToString());
            }
        }

        public static void WriteInfo(string info)
        {
            using (StreamWriter w = File.AppendText("logs.txt"))
            {
                w.WriteLine(info);
            }
        }

        public static DateTime GetCurrentTime()
        {
            return DateTime.UtcNow.AddHours(ConfigUtils.Instance.CititransServerTimeOffset);
        }

        public static DateTime ToDepartureDate(string departDate, string departTime)
        {
            var dateParts = departDate.Split('-');
            var year = int.Parse(dateParts[0]);
            var month = int.Parse(dateParts[1]);
            var day = int.Parse(dateParts[2]);

            var time = departTime.Split('+');
            var timeParts = time[0].Split(':');
            var hour = int.Parse(timeParts[0]);
            var minute = int.Parse(timeParts[1]);
            var second = 0;

            return new DateTime(year, month, day, hour, minute, second);
        }

        //public static TripRequest GetTripRequest(string departureDate, int fromStationId, int toStationId)
        //{
        //    var request = new TripRequest
        //    {
        //        FromStationId = fromStationId,
        //        ToStationId = toStationId,
        //        DepartureDate = departureDate,
        //        Adults = 1
        //    };

        //    return request;
        //}

        //public static GetPointEndByPointStartRequest CreateGetPointEndByPointStartRequest(string departureTime, string pointCodeStart)
        //{
        //    var currentTime = DateTime.Now;

        //    var request = new GetPointEndByPointStartRequest
        //    {
        //        AgentID = ConfigUtils.Instance.LorenaAgentId,
        //        AgentPIN = ConfigUtils.Instance.LorenaAgentPin,
        //        AgenttrxID = ConfigUtils.Instance.LorenaAgenttrxId,
        //        AgentStoreID = ConfigUtils.Instance.LorenaAgentStoreId,
        //        ProductID = ConfigUtils.Instance.LorenaProductId,
        //        DateTimeRequest = currentTime.ToString(AppConstants.DefaultDateTimeFormat),
        //        PointCodeStart = pointCodeStart,
        //        DepartureTime = departureTime,
        //    };

        //    request.Signature = GenerateSignature(request);

        //    return request;
        //}

        //public static GetTrajectRequest CreateGetTrajectRequest(string departureDate, string origin, string destination)
        //{
        //    var currentTime = DateTime.Now;

        //    var request = new GetTrajectRequest
        //    {
        //        AgentID = ConfigUtils.Instance.LorenaAgentId,
        //        AgentPIN = ConfigUtils.Instance.LorenaAgentPin,
        //        AgenttrxID = ConfigUtils.Instance.LorenaAgenttrxId,
        //        AgentStoreID = ConfigUtils.Instance.LorenaAgentStoreId,
        //        ProductID = ConfigUtils.Instance.LorenaProductId,
        //        DateTimeRequest = currentTime.ToString(AppConstants.DefaultDateTimeFormat),
        //        DepartureDate = departureDate,
        //        Origin = origin,
        //        Destination = destination
        //    };

        //    request.Signature = GenerateSignature(request);

        //    return request;
        //}        
    }
}
