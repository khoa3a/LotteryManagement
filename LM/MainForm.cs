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
        private static SouthMondayRepository mondayRepo;
        private static SouthTuesdayRepository tuesdayRepo;
        private static SouthWednesdayRepository wednesdayRepo;
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
            mondayRepo = RepositoryFactory.GetSouthMondayRepo();
            tuesdayRepo = RepositoryFactory.GetSouthTuesdayRepo();
            wednesdayRepo = RepositoryFactory.GetSouthWednesdayRepo();
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

            List<NumberModel> allNumbers = new List<NumberModel>();

            for (int i = 0; i < 10; i++) 
            {
                var dateKey = AppUtils.ToDateKey(currentDate);

                var serviceUrl = ConfigUtils.Instance.LotteryServiceUrl + dateKey + ".html";

                var numbers = CollectData(serviceUrl, currentDate);

                allNumbers.AddRange(numbers);

                currentDate = currentDate.AddDays(-7);
            }

            

            SaveData(currentDate.DayOfWeek, allNumbers).GetAwaiter().GetResult();

            Dispose();
            Close();
        }

        private List<NumberModel> CollectData(string url, DateTime currentDate)
        {
            var dataTable = AppUtils.ToDataTable(url);

            var numbers = ToNumbers(dataTable, currentDate);

            return numbers;

            //DayOfWeek dayOfWeek = currentDate.DayOfWeek;

            //switch (dayOfWeek)
            //{
            //    case DayOfWeek.Friday:
            //        break;
            //}
        }

        private async Task SaveData(DayOfWeek dayOfWeek, List<NumberModel> numbers)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    break;
                case DayOfWeek.Monday:
                    List<SouthMondayEntity> southMondayEntities = numbers.Select(x => new SouthMondayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                    }).ToList();
                    await mondayRepo.InsertMany(southMondayEntities);
                    break;
                case DayOfWeek.Tuesday:
                    List<SouthTuesdayEntity> southTuesdayEntities = numbers.Select(x => new SouthTuesdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                    }).ToList();
                    await tuesdayRepo.InsertMany(southTuesdayEntities);
                    break;
                case DayOfWeek.Wednesday:
                    List<SouthWednesdayEntity> southWednesdayEntities = numbers.Select(x => new SouthWednesdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                    }).ToList();
                    await wednesdayRepo.InsertMany(southWednesdayEntities);
                    break;
            }
        }

        private List<SouthSaturdayEntity> ToSouthSaturdayEntities(List<NumberModel> numbers)
        {
            return numbers.Select(x => new SouthSaturdayEntity
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

