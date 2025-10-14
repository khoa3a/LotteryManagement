// See https://aka.ms/new-console-template for more information
using BLL;
using BLL.Entities;
using Common.Utils;
using DAL;
using System.Data;

class Program
{
    private static SouthMondayRepository mondayRepo;
    private static SouthTuesdayRepository tuesdayRepo;
    private static SouthWednesdayRepository wednesdayRepo;
    private static SouthThursdayRepository thursdayRepo;
    private static SouthFridayRepository fridayRepo;
    private static SouthSaturdayRepository saturdayRepo;
    private static SouthSundayRepository sundayRepo;

    static void Main()
    {
        InitRepository();

        Console.WriteLine("Collector started...");

        var currentDate = DateTime.Now;

        List<NumberModel> allNumbers = new List<NumberModel>();

        for (int i = 0; i < 10; i++)
        {
            var dateKey = AppUtils.ToDateKey(currentDate);

            Console.WriteLine($"{dateKey}...");

            var serviceUrl = ConfigUtils.Instance.LotteryServiceUrl + dateKey + ".html";

            var numbers = CollectData(serviceUrl, currentDate);

            allNumbers.AddRange(numbers);

            currentDate = currentDate.AddDays(-7);
        }

        SaveData(currentDate.DayOfWeek, allNumbers).GetAwaiter().GetResult();

        Console.WriteLine("Collector ended...");
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

    private static async Task SaveData(DayOfWeek dayOfWeek, List<NumberModel> numbers)
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
                    Sub0 = x.Sub0,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
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
                    Sub0 = x.Sub0,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
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
                    Sub0 = x.Sub0,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
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
                    Sub0 = x.Sub0,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
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
                    Sub0 = x.Sub0,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
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
                    Sub0 = x.Sub0,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
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
                    Sub0 = x.Sub0,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
                }).ToList();
                await sundayRepo.InsertMany(southSundayEntities);
                break;
        }
    }

    private static List<NumberModel> CollectData(string url, DateTime currentDate)
    {
        var dataTable = AppUtils.ToDataTable(url);

        var numbers = ToNumbers(dataTable, currentDate);

        return numbers;
    }

    private static List<NumberModel> ToNumbers(DataTable dataTable, DateTime currentDate)
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
                var SubNo1 = No1.ToCharArray();

                if (SubNo1.Length > 2)
                {
                    var lastThree1 = SubNo1.Skip(Math.Max(0, SubNo1.Length - 3)).ToArray();
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name1,
                        Number = No1,
                        SubNumber = $"{SubNo1[1]}{SubNo1[2]}",
                        Sub0 = lastThree1[0].ToString(),
                        Sub1 = lastThree1[1].ToString(),
                        Sub2 = lastThree1[2].ToString(),
                    });
                }
                else
                {
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name1,
                        Number = No1,
                        SubNumber = $"{SubNo1[0]}{SubNo1[1]}",
                        Sub1 = SubNo1[0].ToString(),
                        Sub2 = SubNo1[1].ToString(),
                    });
                }
            }

            var numbers2 = number2.Split('-');
            foreach (var n2 in numbers2)
            {
                var No2 = n2.Trim();
                var SubNo2 = No2.ToCharArray();

                if (SubNo2.Length > 2)
                {
                    var lastThree2 = SubNo2.Skip(Math.Max(0, SubNo2.Length - 3)).ToArray();
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name2,
                        Number = No2,
                        SubNumber = $"{SubNo2[1]}{SubNo2[2]}",
                        Sub0 = lastThree2[0].ToString(),
                        Sub1 = lastThree2[1].ToString(),
                        Sub2 = lastThree2[2].ToString(),
                    });
                }
                else
                {
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name2,
                        Number = No2,
                        SubNumber = $"{SubNo2[0]}{SubNo2[1]}",
                        Sub1 = SubNo2[0].ToString(),
                        Sub2 = SubNo2[1].ToString(),
                    });
                }
            }

            var numbers3 = number3.Split('-');
            foreach (var n3 in numbers3)
            {
                var No3 = n3.Trim();
                var SubNo3 = No3.ToCharArray();

                if (SubNo3.Length > 2)
                {
                    var lastThree3 = SubNo3.Skip(Math.Max(0, SubNo3.Length - 3)).ToArray();
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name3,
                        Number = No3,
                        SubNumber = $"{SubNo3[1]}{SubNo3[2]}",
                        Sub0 = lastThree3[0].ToString(),
                        Sub1 = lastThree3[1].ToString(),
                        Sub2 = lastThree3[2].ToString(),
                    });
                }
                else
                {
                    result.Add(new NumberModel
                    {
                        DateKey = dateKey,
                        Name = name3,
                        Number = No3,
                        SubNumber = $"{SubNo3[0]}{SubNo3[1]}",
                        Sub1 = SubNo3[0].ToString(),
                        Sub2 = SubNo3[1].ToString(),
                    });
                }
            }

            if (!string.IsNullOrEmpty(number4))
            {
                var numbers4 = number4.Split('-');
                foreach (var n4 in numbers4)
                {
                    var No4 = n4.Trim();
                    var SubNo4 = No4.ToCharArray();

                    if (SubNo4.Length > 2)
                    {
                        var lastThree4 = SubNo4.Skip(Math.Max(0, SubNo4.Length - 3)).ToArray();
                        result.Add(new NumberModel
                        {
                            DateKey = dateKey,
                            Name = name4,
                            Number = No4,
                            SubNumber = $"{SubNo4[1]}{SubNo4[2]}",
                            Sub0 = lastThree4[0].ToString(),
                            Sub1 = lastThree4[1].ToString(),
                            Sub2 = lastThree4[2].ToString(),
                        });
                    }
                    else
                    {
                        result.Add(new NumberModel
                        {
                            DateKey = dateKey,
                            Name = name4,
                            Number = No4,
                            SubNumber = $"{SubNo4[0]}{SubNo4[1]}",
                            Sub1 = SubNo4[0].ToString(),
                            Sub2 = SubNo4[1].ToString(),
                        });
                    }
                }
            }
        }

        return result;
    }
}