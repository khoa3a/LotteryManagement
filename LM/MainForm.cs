using Common.Utils;
using DAL;
using BLL;
using BLL.Entities;
using System.Data;

namespace LM
{
    public partial class MainForm : Form
    {
        private static SouthMondayRepository mondayRepo;
        private static SouthTuesdayRepository tuesdayRepo;
        private static SouthWednesdayRepository wednesdayRepo;
        private static SouthThursdayRepository thursdayRepo;
        private static SouthFridayRepository fridayRepo;
        private static SouthSaturdayRepository saturdayRepo;
        private static SouthSundayRepository sundayRepo;

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
            thursdayRepo = RepositoryFactory.GetSouthThursdayRepo();
            fridayRepo = RepositoryFactory.GetSouthFridayRepo();
            saturdayRepo = RepositoryFactory.GetSouthSaturdayRepo();
            sundayRepo = RepositoryFactory.GetSouthSundayRepo();
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

            MessageBox.Show("Done");

            //Dispose();
            //Close();
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
                case DayOfWeek.Monday:
                    List<SouthMondayEntity> southMondayEntities = numbers.Select(x => new SouthMondayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        SubNumber = x.SubNumber,
                    }).ToList();
                    await mondayRepo.InsertMany(southMondayEntities);
                    break;
                case DayOfWeek.Tuesday:
                    List<SouthTuesdayEntity> southTuesdayEntities = numbers.Select(x => new SouthTuesdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        SubNumber = x.SubNumber,
                    }).ToList();
                    await tuesdayRepo.InsertMany(southTuesdayEntities);
                    break;
                case DayOfWeek.Wednesday:
                    List<SouthWednesdayEntity> southWednesdayEntities = numbers.Select(x => new SouthWednesdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        SubNumber = x.SubNumber,
                    }).ToList();
                    await wednesdayRepo.InsertMany(southWednesdayEntities);
                    break;
                case DayOfWeek.Thursday:
                    List<SouthThursdayEntity> southThursdayEntities = numbers.Select(x => new SouthThursdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        SubNumber = x.SubNumber,
                    }).ToList();
                    await thursdayRepo.InsertMany(southThursdayEntities);
                    break;
                case DayOfWeek.Friday:
                    List<SouthFridayEntity> southFridayEntities = numbers.Select(x => new SouthFridayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        SubNumber = x.SubNumber,
                    }).ToList();
                    await fridayRepo.InsertMany(southFridayEntities);
                    break;
                case DayOfWeek.Saturday:
                    List<SouthSaturdayEntity> southSaturdayEntities = numbers.Select(x => new SouthSaturdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        SubNumber = x.SubNumber,
                    }).ToList();
                    await saturdayRepo.InsertMany(southSaturdayEntities);
                    break;
                case DayOfWeek.Sunday:
                    List<SouthSundayEntity> southSundayEntities = numbers.Select(x => new SouthSundayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        SubNumber = x.SubNumber,
                    }).ToList();
                    await sundayRepo.InsertMany(southSundayEntities);
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

            var name4 = string.Empty;
            if (dataTable.Columns.Count > 4)
            {
                name4 = dataTable.Columns[4].ColumnName;
            }

            for (var index = 1; index < dataTable.Rows.Count; index++)
            {
                var number1 = dataTable.Rows[index][1].ToString();
                var number2 = dataTable.Rows[index][2].ToString();
                var number3 = dataTable.Rows[index][3].ToString();

                var number4 = string.Empty;
                if (!string.IsNullOrEmpty(name4))
                {
                    number4 = dataTable.Rows[index][4].ToString();
                }

                var numbers1 = number1.Split('-');
                foreach (var n1 in numbers1)
                {
                    var No1 = n1.Trim();
                    var SubNo1 = No1;
                    if (No1.Length > 2)
                    {
                        SubNo1 = No1.Substring(No1.Length - 2);
                    }
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name1,
                        Number = No1,
                        SubNumber = SubNo1
                    });
                }

                var numbers2 = number2.Split('-');
                foreach (var n2 in numbers2)
                {
                    var No2 = n2.Trim();
                    var SubNo2 = No2;
                    if (No2.Length > 2)
                    {
                        SubNo2 = No2.Substring(No2.Length - 2);
                    }
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name2,
                        Number = No2,
                        SubNumber = SubNo2
                    });
                }

                var numbers3 = number3.Split('-');
                foreach (var n3 in numbers3)
                {
                    var No3 = n3.Trim();
                    var SubNo3 = No3;
                    if (No3.Length > 2)
                    {
                        SubNo3 = No3.Substring(No3.Length - 2);
                    }
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name3,
                        Number = No3,
                        SubNumber = SubNo3
                    });
                }

                if (!string.IsNullOrEmpty(number4))
                {
                    var numbers4 = number4.Split('-');
                    foreach (var n4 in numbers4)
                    {
                        var No4 = n4.Trim();
                        var SubNo4 = No4;
                        if (No4.Length > 2)
                        {
                            SubNo4 = No4.Substring(No4.Length - 2);
                        }
                        result.Add(new NumberModel
                        {
                            DateKey = dateKey,
                            Name = name4,
                            Number = No4,
                            SubNumber = SubNo4
                        });
                    }
                }
            }

            return result;
        }
    }
}

