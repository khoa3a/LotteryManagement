using HtmlAgilityPack;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utils
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

        public static DataTable ToDataTable(string url)
        {
            // url = "https://www.minhngoc.com.vn/ket-qua-xo-so/28-02-2021.html";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            List<string> listData = new List<string>();

            var data = doc.DocumentNode.SelectNodes("//table[contains(@class,'bkqmiennam')]");

            foreach (var table_miennam in data)
            {
                doc.LoadHtml(table_miennam.InnerHtml);
                var data2 = doc.DocumentNode.SelectNodes("//table//tbody//tr");

                var rows = data2.Select(tr => tr
                    .Elements("td")
                    .Select(td => System.Net.WebUtility.HtmlDecode(td.InnerHtml).Trim())
                    .ToArray());
                foreach (var row in rows)
                {
                    var temp = HtmlToPlainText(row[0].Replace("<div>", "").Replace("</div>", "-").Trim());
                    var text = string.Join(" - ", temp.Split('-').Where(x => !string.IsNullOrEmpty(x)).ToArray());
                    listData.Add(text);
                }
                break;
            }

            var listOfLists = new List<IEnumerable<string>>();
            for (int i = 0; i < listData.Count(); i += 11)
            {
                listOfLists.Add(listData.Skip(i).Take(11));
            }
            var table = new DataTable();
            foreach (var item in listOfLists)
            {
                table.Columns.Add(item.ToList().FirstOrDefault());
            }

            for (int i = 1; i < 11; i++)
            {
                var dr = table.NewRow();
                int j = 0;
                foreach (var item in listOfLists)
                {
                    dr[j] = item.ToArray()[i];
                    j++;
                }
                table.Rows.Add(dr);

            }
            return table;
        }

        public static DateTime GetCurrentTime()
        {
            return DateTime.UtcNow.AddHours(ConfigUtils.Instance.CititransServerTimeOffset);
        }

        public static string ToDateKey(DateTime input)
        {
            return input.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
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

        private static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";
            const string stripFormatting = @"<[^>]*(>|$)";
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            text = System.Net.WebUtility.HtmlDecode(text);
            text = tagWhiteSpaceRegex.Replace(text, "><");
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }
    }
}
