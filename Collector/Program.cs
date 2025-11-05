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

    private static NorthRepository northRepo;
    private static NorthMondayRepository northMondayRepo;
    private static NorthTuesdayRepository northTuesdayRepo;
    private static NorthWednesdayRepository northWednesdayRepo;
    private static NorthThursdayRepository northThursdayRepo;

    public static bool NORTH_DATA = true;
    public static int WEEK_COUNT = 20; // 5 years (52 x 5)
    public static int DAY_COUNT = 1825; // 5 years (365 x 5)


    static void Main()
    {
        InitRepository();

        Console.WriteLine("Collector started...");

        var subtract = NORTH_DATA ? -1 : -7;

        var currentDate = DateTime.Now.AddDays(subtract);

        List<NumberModel> allNumbers = new List<NumberModel>();

        var count = NORTH_DATA ? DAY_COUNT : WEEK_COUNT;
        
        // collect only 1 day        
        count = 2;

        for (int i = 0; i < count; i++)
        {
            var dateKey = AppUtils.ToDateKey(currentDate);

            var baseUrl = ConfigUtils.Instance.LotteryServiceUrl;
            if (NORTH_DATA)
            {
                baseUrl += "mien-bac/";
            }

            var serviceUrl = baseUrl + dateKey + ".html";

            Console.WriteLine($"{serviceUrl}...");


            var numbers = CollectData(serviceUrl, currentDate);

            allNumbers.AddRange(numbers);



            currentDate = currentDate.AddDays(subtract);
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

        northRepo = RepositoryFactory.GetNorthRepo();
        northMondayRepo = RepositoryFactory.GetNorthMondayRepo();
        northTuesdayRepo = RepositoryFactory.GetNorthTuesdayRepo();
        northWednesdayRepo = RepositoryFactory.GetNorthWednesdayRepo();
        northThursdayRepo = RepositoryFactory.GetNorthThursdayRepo();
    }

    private static async Task SaveData(DayOfWeek dayOfWeek, List<NumberModel> numbers)
    {
        if (NORTH_DATA)
        {
            //List<NorthEntity> northEntities = new List<NorthEntity>();

            //foreach (var num in numbers)
            //{ 
            //    var northEntity = new NorthEntity();

            //    northEntity.Date = num.Date;
            //    northEntity.Number = num.Number.Trim();
            //    northEntity.Name = num.Name;
            //    northEntity.Day = num.Day;
            //    northEntity.Month = num.Month;
            //    northEntity.Year = num.Year;
            //    northEntity.Sub1 = num.Sub1;
            //    northEntity.Sub2 = num.Sub2;
            //    northEntity.Sub3 = num.Sub3;
            //    northEntity.Sub4 = num.Sub4;
            //    northEntity.Sub2Number = num.Sub2Number;
            //    northEntity.Sub3Number = num.Sub3Number;
            //    northEntity.Sub4Number = num.Sub4Number;

            //    northEntities.Add(northEntity);
            //}

            //await northRepo.InsertMany(northEntities);

            List<NorthEntity> northEntities = numbers.Select(x => new NorthEntity
            {
                Date = x.Date,
                Day = x.Day,
                Month = x.Month,
                Year = x.Year,
                Name = x.Name,
                Number = x.Number,
                Sub2Number = x.Sub2Number,
                Sub3Number = x.Sub3Number,
                Sub4Number = x.Sub4Number,
                Sub1 = x.Sub1,
                Sub2 = x.Sub2,
                Sub3 = x.Sub3,
                Sub4 = x.Sub4,
            }).ToList();
            await northRepo.InsertMany(northEntities);

            return;
        }

        switch (dayOfWeek)
        {
            case DayOfWeek.Monday:
                if (NORTH_DATA)
                {
                    List<NorthMondayEntity> northMondayEntities = numbers.Select(x => new NorthMondayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number.Trim(),
                        Sub2Number = x.Sub2Number.Trim(),
                        Sub3Number = x.Sub3Number.Trim(),
                        Sub4Number = x.Sub4Number.Trim(),
                        Sub1 = x.Sub1,
                        Sub2 = x.Sub2,
                        Sub3 = x.Sub3,
                        Sub4 = x.Sub4,
                    }).ToList();
                    await northMondayRepo.InsertMany(northMondayEntities);
                }
                else
                {
                    List<SouthMondayEntity> southMondayEntities = numbers.Select(x => new SouthMondayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        Sub2Number = x.Sub2Number,
                        Sub3Number = x.Sub3Number,
                        Sub4Number = x.Sub4Number,
                        Sub1 = x.Sub1,
                        Sub2 = x.Sub2,
                        Sub3 = x.Sub3,
                        Sub4 = x.Sub4,
                    }).ToList();
                    await mondayRepo.InsertMany(southMondayEntities);
                }

                break;
            case DayOfWeek.Tuesday:
                if (NORTH_DATA)
                {
                    List<NorthTuesdayEntity> northTuesdayEntities = numbers.Select(x => new NorthTuesdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number.Trim(),
                        Sub2Number = x.Sub2Number.Trim(),
                        Sub3Number = x.Sub3Number.Trim(),
                        Sub4Number = x.Sub4Number.Trim(),
                        Sub1 = x.Sub1,
                        Sub2 = x.Sub2,
                        Sub3 = x.Sub3,
                        Sub4 = x.Sub4,
                    }).ToList();
                    await northTuesdayRepo.InsertMany(northTuesdayEntities);
                }
                else
                {
                    List<SouthTuesdayEntity> southTuesdayEntities = numbers.Select(x => new SouthTuesdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        Sub2Number = x.Sub2Number,
                        Sub3Number = x.Sub3Number,
                        Sub4Number = x.Sub4Number,
                        Sub1 = x.Sub1,
                        Sub2 = x.Sub2,
                        Sub3 = x.Sub3,
                        Sub4 = x.Sub4,
                    }).ToList();
                    await tuesdayRepo.InsertMany(southTuesdayEntities);
                }
                break;
            case DayOfWeek.Wednesday:
                if (NORTH_DATA)
                {
                    List<NorthWednesdayEntity> northWednesdayEntities = numbers.Select(x => new NorthWednesdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number.Trim(),
                        Sub2Number = x.Sub2Number.Trim(),
                        Sub3Number = x.Sub3Number.Trim(),
                        Sub4Number = x.Sub4Number.Trim(),
                        Sub1 = x.Sub1,
                        Sub2 = x.Sub2,
                        Sub3 = x.Sub3,
                        Sub4 = x.Sub4,
                    }).ToList();
                    await northWednesdayRepo.InsertMany(northWednesdayEntities);
                }
                else
                {
                    List<SouthWednesdayEntity> southWednesdayEntities = numbers.Select(x => new SouthWednesdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        Sub2Number = x.Sub2Number,
                        Sub3Number = x.Sub3Number,
                        Sub4Number = x.Sub4Number,
                        Sub1 = x.Sub1,
                        Sub2 = x.Sub2,
                        Sub3 = x.Sub3,
                        Sub4 = x.Sub4,
                    }).ToList();
                    await wednesdayRepo.InsertMany(southWednesdayEntities);
                }
                break;
            case DayOfWeek.Thursday:
                if (NORTH_DATA)
                {
                    List<NorthThursdayEntity> northThursdayEntities = numbers.Select(x => new NorthThursdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        Sub2Number = x.Sub2Number,
                        Sub3Number = x.Sub3Number,
                        Sub4Number = x.Sub4Number,
                        Sub1 = x.Sub1,
                        Sub2 = x.Sub2,
                        Sub3 = x.Sub3,
                        Sub4 = x.Sub4,
                    }).ToList();
                    await northThursdayRepo.InsertMany(northThursdayEntities);
                }
                else
                {
                    List<SouthThursdayEntity> southThursdayEntities = numbers.Select(x => new SouthThursdayEntity
                    {
                        DateKey = x.DateKey,
                        Name = x.Name,
                        Number = x.Number,
                        Sub2Number = x.Sub2Number,
                        Sub3Number = x.Sub3Number,
                        Sub4Number = x.Sub4Number,
                        Sub1 = x.Sub1,
                        Sub2 = x.Sub2,
                        Sub3 = x.Sub3,
                        Sub4 = x.Sub4,
                    }).ToList();
                    await thursdayRepo.InsertMany(southThursdayEntities);
                }

                break;
            case DayOfWeek.Friday:
                List<SouthFridayEntity> southFridayEntities = numbers.Select(x => new SouthFridayEntity
                {
                    DateKey = x.DateKey,
                    Name = x.Name,
                    Number = x.Number.Trim(),
                    Sub2Number = x.Sub2Number.Trim(),
                    Sub3Number = x.Sub3Number.Trim(),
                    Sub4Number = x.Sub4Number.Trim(),
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
                    Sub3 = x.Sub3,
                    Sub4 = x.Sub4,
                }).ToList();
                await fridayRepo.InsertMany(southFridayEntities);
                break;
            case DayOfWeek.Saturday:
                List<SouthSaturdayEntity> southSaturdayEntities = numbers.Select(x => new SouthSaturdayEntity
                {
                    DateKey = x.DateKey,
                    Name = x.Name,
                    Number = x.Number,
                    Sub2Number = x.Sub2Number,
                    Sub3Number = x.Sub3Number,
                    Sub4Number = x.Sub4Number,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
                    Sub3 = x.Sub3,
                    Sub4 = x.Sub4,
                }).ToList();
                await saturdayRepo.InsertMany(southSaturdayEntities);
                break;
            case DayOfWeek.Sunday:
                List<SouthSundayEntity> southSundayEntities = numbers.Select(x => new SouthSundayEntity
                {
                    DateKey = x.DateKey,
                    Name = x.Name,
                    Number = x.Number,
                    Sub2Number = x.Sub2Number,
                    Sub3Number = x.Sub3Number,
                    Sub4Number = x.Sub4Number,
                    Sub1 = x.Sub1,
                    Sub2 = x.Sub2,
                    Sub3 = x.Sub3,
                    Sub4 = x.Sub4,
                }).ToList();
                await sundayRepo.InsertMany(southSundayEntities);
                break;
        }
    }

    private static List<NumberModel> CollectData(string url, DateTime currentDate)
    {
        var result = new List<NumberModel>();
        if (!NORTH_DATA)
        {
            var dataTable = AppUtils.ToDataTable(url);

            result = ToNumbers(dataTable, currentDate);
        }
        else
        {
            var listData = AppUtils.ToNorthData(url);

            result = ToNumbers(listData, currentDate);
        }

        return result;
    }

    private static List<NumberModel> ToNumbers(List<string> listData, DateTime currentDate)
    {
        var result = new List<NumberModel>();

        foreach (var data in listData)
        {
            var chars = data.Trim().ToCharArray();
            var len = chars.Length;

            if (len == 2)
            {
                result.Add(new NumberModel
                {
                    DateKey = currentDate.ToString("dd-MM-yyyy"),
                    Date = currentDate,
                    Day = currentDate.Day,
                    Month = currentDate.Month,
                    Year = currentDate.Year,
                    Name = "MB",
                    Number = data.Trim(),
                    Sub2Number = data.Trim(),
                    Sub3 = Convert.ToInt32(chars[0].ToString()),
                    Sub4 = Convert.ToInt32(chars[1].ToString()),
                });
            }
            else if (len == 3)
            {
                result.Add(new NumberModel
                {
                    DateKey = currentDate.ToString("dd-MM-yyyy"),
                    Date = currentDate,
                    Day = currentDate.Day,
                    Month = currentDate.Month,
                    Year = currentDate.Year,
                    Name = "MB",
                    Number = data.Trim(),
                    Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                    Sub3Number = data.Trim(),
                    Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                    Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                    Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                });
            }
            else if (len == 4)
            {
                result.Add(new NumberModel
                {
                    DateKey = currentDate.ToString("dd-MM-yyyy"),
                    Date = currentDate,
                    Day = currentDate.Day,
                    Month = currentDate.Month,
                    Year = currentDate.Year,
                    Name = "MB",
                    Number = data.Trim(),
                    Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                    Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                    Sub4Number = data.Trim(),
                    Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                    Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                    Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                    Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                });
            }
            else if (len == 5)
            {
                result.Add(new NumberModel
                {
                    DateKey = currentDate.ToString("dd-MM-yyyy"),
                    Date = currentDate,
                    Day = currentDate.Day,
                    Month = currentDate.Month,
                    Year = currentDate.Year,
                    Name = "MB",
                    Number = data.Trim(),
                    Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                    Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                    Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                    Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                    Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                    Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                    Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                });
            }            
        }

        return result;
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
            foreach (var data1 in numbers1)
            {
                var chars = data1.Trim().ToCharArray();
                var len = chars.Length;

                if (len == 2)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name1,
                        Number = data1.Trim(),
                        Sub2Number = data1.Trim(),
                        Sub3 = Convert.ToInt32(chars[0].ToString()),
                        Sub4 = Convert.ToInt32(chars[1].ToString()),
                    });
                }
                else if (len == 3)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name1,
                        Number = data1.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = data1.Trim(),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 4)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name1,
                        Number = data1.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = data1.Trim(),
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 5)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name1,
                        Number = data1.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 6)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name1,
                        Number = data1.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
            }

            var numbers2 = number2.Split('-');
            foreach (var data2 in numbers2)
            {
                var chars = data2.Trim().ToCharArray();
                var len = chars.Length;

                if (len == 2)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name2,
                        Number = data2.Trim(),
                        Sub2Number = data2.Trim(),
                        Sub3 = Convert.ToInt32(chars[0].ToString()),
                        Sub4 = Convert.ToInt32(chars[1].ToString()),
                    });
                }
                else if (len == 3)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name2,
                        Number = data2.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = data2.Trim(),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 4)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name2,
                        Number = data2.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = data2.Trim(),
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 5)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name2,
                        Number = data2.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 6)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name2,
                        Number = data2.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
            }

            var numbers3 = number3.Split('-');
            foreach (var data3 in numbers3)
            {
                var chars = data3.Trim().ToCharArray();
                var len = chars.Length;

                if (len == 2)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name3,
                        Number = data3.Trim(),
                        Sub2Number = data3.Trim(),
                        Sub3 = Convert.ToInt32(chars[0].ToString()),
                        Sub4 = Convert.ToInt32(chars[1].ToString()),
                    });
                }
                else if (len == 3)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name3,
                        Number = data3.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = data3.Trim(),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 4)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name3,
                        Number = data3.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = data3.Trim(),
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 5)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name3,
                        Number = data3.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
                else if (len == 6)
                {
                    result.Add(new NumberModel
                    {
                        DateKey = currentDate.ToString("dd-MM-yyyy"),
                        Name = name3,
                        Number = data3.Trim(),
                        Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                        Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                        Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                        Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                        Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                        Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                    });
                }
            }

            if (!string.IsNullOrEmpty(number4))
            {
                var numbers4 = number4.Split('-');
                foreach (var data4 in numbers4)
                {
                    var chars = data4.Trim().ToCharArray();
                    var len = chars.Length;

                    if (len == 2)
                    {
                        result.Add(new NumberModel
                        {
                            DateKey = currentDate.ToString("dd-MM-yyyy"),
                            Name = name4,
                            Number = data4.Trim(),
                            Sub2Number = data4.Trim(),
                            Sub3 = Convert.ToInt32(chars[0].ToString()),
                            Sub4 = Convert.ToInt32(chars[1].ToString()),
                        });
                    }
                    else if (len == 3)
                    {
                        result.Add(new NumberModel
                        {
                            DateKey = currentDate.ToString("dd-MM-yyyy"),
                            Name = name4,
                            Number = data4.Trim(),
                            Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                            Sub3Number = data4.Trim(),
                            Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                            Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                            Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                        });
                    }
                    else if (len == 4)
                    {
                        result.Add(new NumberModel
                        {
                            DateKey = currentDate.ToString("dd-MM-yyyy"),
                            Name = name4,
                            Number = data4.Trim(),
                            Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                            Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                            Sub4Number = data4.Trim(),
                            Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                            Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                            Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                            Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                        });
                    }
                    else if (len == 5)
                    {
                        result.Add(new NumberModel
                        {
                            DateKey = currentDate.ToString("dd-MM-yyyy"),
                            Name = name4,
                            Number = data4.Trim(),
                            Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                            Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                            Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                            Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                            Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                            Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                            Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                        });
                    }
                    else if (len == 6)
                    {
                        result.Add(new NumberModel
                        {
                            DateKey = currentDate.ToString("dd-MM-yyyy"),
                            Name = name4,
                            Number = data4.Trim(),
                            Sub2Number = $"{chars[len - 2]}{chars[len - 1]}",
                            Sub3Number = $"{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                            Sub4Number = $"{chars[len - 4]}{chars[len - 3]}{chars[len - 2]}{chars[len - 1]}",
                            Sub1 = Convert.ToInt32(chars[len - 4].ToString()),
                            Sub2 = Convert.ToInt32(chars[len - 3].ToString()),
                            Sub3 = Convert.ToInt32(chars[len - 2].ToString()),
                            Sub4 = Convert.ToInt32(chars[len - 1].ToString()),
                        });
                    }
                }
            }
        }

        return result;
    }
}