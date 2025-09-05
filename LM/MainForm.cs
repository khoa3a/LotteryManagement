using HtmlAgilityPack;
using LM.DAL;
using LM.Models;
using LM.Models.Entities;
using LM.Utils;
using System.Data;
using System.Globalization;
using System.Security.Policy;

namespace LM
{
    public partial class MainForm : Form
    {
        private static SouthFridayRepository fridayRepo;
        private static SouthSaturdayRepository saturdayRepo;

        public MainForm()
        {
            InitializeComponent();
            InitializeLayout();
            InitRepository();
            InitializeEvent();
        }

        private static void InitRepository()
        {
            fridayRepo = RepositoryFactory.GetSouthFridayRepo();
            saturdayRepo = RepositoryFactory.GetSouthSaturdayRepo();
        }

        private void InitializeLayout()
        {
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeEvent()
        {
            button1.Click += new EventHandler(HandleButton1Click);
        }

        private void HandleButton1Click(object sender, EventArgs e)
        {
            var currentDate = dateTimePicker1.Value;
            var dateKey = AppUtils.ToDateKey(currentDate);

            var serviceUrl = ConfigUtils.Instance.LotteryServiceUrl + dateKey + ".html";

            CollectData(serviceUrl, currentDate);
        }

        private void CollectData(string url, DateTime currentDate)
        {
            var dataTable = AppUtils.ToDataTable(url);

            var numbers = ToNumbers(dataTable, currentDate);

            List<SouthSaturdayEntity> southSaturdayEntities = ToSouthSaturdayEntities(numbers);

            foreach (var batch in southSaturdayEntities.Batches(AppConstants.DefaultBatchSize))
            {
                saturdayRepo.InsertMany(batch).GetAwaiter().GetResult();
            }

            //DayOfWeek dayOfWeek = currentDate.DayOfWeek;

            //switch (dayOfWeek)
            //{
            //    case DayOfWeek.Friday:
            //        break;
            //}
        }

        private List<SouthSaturdayEntity> ToSouthSaturdayEntities(List<NumberModel> numbers)
        { 
            return numbers.Select(x=> new SouthSaturdayEntity 
            {
                DateKey = x.DateKey,
                Name = x.Name,
                Number = x.Number
            }).ToList();
        }

        private List<NumberModel> ToNumbers(DataTable dataTable, DateTime currentDate)
        { 
            var result = new List<NumberModel>();

            var dateKey = AppUtils.ToDateKey(currentDate);
            var name1 = dataTable.Columns[1].ColumnName;
            var name2 = dataTable.Columns[2].ColumnName;
            var name3 = dataTable.Columns[3].ColumnName;

            for (var index = 1; index < dataTable.Rows.Count; index++)
            {
                var number1 = dataTable.Rows[index][1].ToString();
                var number2 = dataTable.Rows[index][2].ToString();
                var number3 = dataTable.Rows[index][3].ToString();

                var numbers1 = number1.Split('-');
                foreach (var n1 in numbers1)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name1,
                        Number = n1.Trim()
                    });
                }

                var numbers2 = number2.Split('-');
                foreach (var n2 in numbers2)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name2,
                        Number = n2.Trim()
                    });
                }

                var numbers3 = number3.Split('-');
                foreach (var n3 in numbers3)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name3,
                        Number = n3.Trim()
                    });
                }
            }

            return result;
        }
    }
}

