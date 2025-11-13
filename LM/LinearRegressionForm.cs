using BLL;
using BLL.Search;
using Common;
using DAL;
using System.Windows.Forms.DataVisualization.Charting;

namespace LM
{
    public partial class LinearRegressionForm : Form
    {

        private NorthRepository northRepo;        
        
        private SouthSundayRepository southSundayRepo;
        private SouthMondayRepository southMondayRepo;
        private SouthTuesdayRepository southTuesdayRepo;
        private SouthWednesdayRepository southWednesdayRepo;
        private SouthThursdayRepository southThursdayRepo;
        private SouthFridayRepository southFridayRepo;
        private SouthSaturdayRepository southSaturdayRepo;

        private List<string> tuesdayNames = new List<string> { "Bến Tre", "Vũng Tàu", "Bạc Liêu" };
        private List<string> wednesdayNames = new List<string> { "Đồng Nai", "Cần Thơ", "Sóc Trăng" };
        private List<string> thursdayNames = new List<string> { "Tây Ninh", "An Giang", "Bình Thuận" };

        public LinearRegressionForm()
        {
            InitializeComponent();

            northRepo = RepositoryFactory.GetNorthRepo();
            southFridayRepo = RepositoryFactory.GetSouthFridayRepo();
            southSaturdayRepo = RepositoryFactory.GetSouthSaturdayRepo();
            southSundayRepo = RepositoryFactory.GetSouthSundayRepo();
            southMondayRepo = RepositoryFactory.GetSouthMondayRepo();
            southTuesdayRepo = RepositoryFactory.GetSouthTuesdayRepo();
            southWednesdayRepo = RepositoryFactory.GetSouthWednesdayRepo();
            southThursdayRepo = RepositoryFactory.GetSouthThursdayRepo();

            InitializeEvent();

            InitializeData();
        }

        private void InitializeEvent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Paint += LinearRegressionForm_Paint;

            //cmComboBoxQuotation.OnSelectedIndexChanged += new EventHandler(HandleQuotationChange);
            comboBoxDoW.SelectedIndexChanged += new EventHandler(HandleDoWChange);
        }

        private void HandleDoWChange(object sender, EventArgs e)
        {
            //PopulateAmountTextBox();
            var dayOfWeek = comboBoxDoW.SelectedValue;

            switch (dayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    comboBoxName.DataSource = tuesdayNames;
                    break;
                case DayOfWeek.Wednesday:
                    comboBoxName.DataSource = wednesdayNames;
                    break;
                case DayOfWeek.Thursday:
                    comboBoxName.DataSource = thursdayNames;
                    break;
            }
        }

        private void InitializeData()
        {
            var data = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            PopulateComboBox(comboBoxSub1, data);
            PopulateComboBox(comboBoxSub2, data);
            PopulateComboBox(comboBoxSub3, data);
            PopulateComboBox(comboBoxSub4, data);

            comboBoxDoW.DataSource = Enum.GetValues(typeof(DayOfWeek));

            //dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dateTimePickerFrom.Value = DateTime.Now.AddMonths(-6);
        }

        private void PopulateComboBox(ComboBox comboBox, List<int> models, bool addDefaultItem = true)
        {
            comboBox.Items.Clear();
            if (addDefaultItem)
            {
                var defaultItem = "-1";

                comboBox.Items.Add(defaultItem);
            }

            foreach (var model in models)
            {
                comboBox.Items.Add(model);
            }

            comboBox.SelectedIndex = 0;
        }

        private Dictionary<string, int> GetSouthData(SearchCriteria criteria)
        {
            var listNumbers = new List<string>();

            if (criteria is SouthSundaySearchCriteria sundaySearchCriteria)
            {
                listNumbers = southSundayRepo.SearchAll(sundaySearchCriteria).Select(x => x.Sub2Number).ToList();
            }
            else if (criteria is SouthMondaySearchCriteria mondaySearchCriteria)
            {
                listNumbers = southMondayRepo.SearchAll(mondaySearchCriteria).Select(x => x.Sub2Number).ToList();
            }
            else if (criteria is SouthTuesdaySearchCriteria tuesdaySearchCriteria)
            {
                listNumbers = southTuesdayRepo.SearchAll(tuesdaySearchCriteria).Select(x => x.Sub2Number).ToList();
            }
            else if (criteria is SouthWednesdaySearchCriteria wednesdaySearchCriteria)
            {
                listNumbers = southWednesdayRepo.SearchAll(wednesdaySearchCriteria).Select(x => x.Sub2Number).ToList();
            }
            else if (criteria is SouthThursdaySearchCriteria thursdaySearchCriteria)
            {
                listNumbers = southThursdayRepo.SearchAll(thursdaySearchCriteria).Select(x => x.Sub2Number).ToList();
            }
            else if (criteria is SouthFridaySearchCriteria fridaySearchCriteria)
            {
                listNumbers = southFridayRepo.SearchAll(fridaySearchCriteria).Select(x => x.Sub2Number).ToList();
            }
            else if (criteria is SouthSaturdaySearchCriteria saturdaySearchCriteria)
            {
                listNumbers = southSaturdayRepo.SearchAll(saturdaySearchCriteria).Select(x => x.Sub2Number).ToList();
            }            

            Dictionary<string, int> result = listNumbers
                                    .GroupBy(x => x)
                                    .ToDictionary(g => g.Key.ToString(), g => g.Count());

            return result;
        }

        private Dictionary<string, int> GetNorthData(NorthSearchCriteria criteria)
        {
            List<string> listNumbers = new List<string>();

            if (criteria.Subs.SafeAny())
            {
                listNumbers = northRepo.SearchAll(criteria).Select(x => x.Sub4Number).ToList();
            }
            else
            {
                listNumbers = northRepo.SearchAll(criteria).Select(x => x.Sub2Number).ToList();
            }

            Dictionary<string, int> result = listNumbers
                                    .GroupBy(x => x)
                                    .ToDictionary(g => g.Key.ToString(), g => g.Count());

            return result;
        }

        private SearchCriteria GetSouthSearchCriteria()
        {
            List<int?> subs = new List<int?>();

            int sub = Convert.ToInt32(comboBoxSub3.SelectedItem);
            if (sub >= 0)
            {
                subs.Add(sub);
            }

            sub = Convert.ToInt32(comboBoxSub4.SelectedItem);
            if (sub >= 0)
            {
                subs.Add(sub);
            }

            //sub = Convert.ToInt32(comboBoxSub3.SelectedItem);
            //if (sub >= 0)
            //{
            //    subs.Add(sub);
            //}

            //sub = Convert.ToInt32(comboBoxSub4.SelectedItem);
            //if (sub >= 0)
            //{
            //    subs.Add(sub);
            //}

            var dayOfWeek = comboBoxDoW.SelectedValue;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    var criteriaMonday = new SouthMondaySearchCriteria
                    {
                        Subs = subs,
                        From = dateTimePickerFrom.Value
                    };

                    return criteriaMonday;

                case DayOfWeek.Tuesday:
                    var criteriaTuesday = new SouthTuesdaySearchCriteria
                    {
                        Subs = subs,
                        Name = comboBoxName.Text,
                        From = dateTimePickerFrom.Value
                    };

                    return criteriaTuesday;

                case DayOfWeek.Wednesday:
                    var criteriaWednesday = new SouthWednesdaySearchCriteria
                    {
                        Subs = subs,
                        Name = comboBoxName.Text,
                        From = dateTimePickerFrom.Value
                    };

                    return criteriaWednesday;

                case DayOfWeek.Thursday:
                    var criteriaThursday = new SouthThursdaySearchCriteria
                    {
                        Subs = subs,
                        Name = comboBoxName.Text,
                        From = dateTimePickerFrom.Value
                    };

                    return criteriaThursday;

                case DayOfWeek.Friday:
                    var criteriaFriday = new SouthFridaySearchCriteria
                    {
                        Subs = subs,
                        From = dateTimePickerFrom.Value
                    };

                    return criteriaFriday;

                case DayOfWeek.Saturday:
                    var criteriaSaturday = new SouthSaturdaySearchCriteria
                    {
                        Subs = subs,
                        From = dateTimePickerFrom.Value
                    };

                    return criteriaSaturday;

                case DayOfWeek.Sunday:
                    var criteriaSunday = new SouthSundaySearchCriteria
                    {
                        Subs = subs,
                        From = dateTimePickerFrom.Value
                    };

                    return criteriaSunday;
            }

            return new SearchCriteria();
        }


        private NorthSearchCriteria GetSearchCriteria()
        {
            List<int?> subs = new List<int?>();

            int sub = Convert.ToInt32(comboBoxSub1.SelectedItem);
            if (sub >= 0)
            {
                subs.Add(sub);
            }

            sub = Convert.ToInt32(comboBoxSub2.SelectedItem);
            if (sub >= 0)
            {
                subs.Add(sub);
            }

            sub = Convert.ToInt32(comboBoxSub3.SelectedItem);
            if (sub >= 0)
            {
                subs.Add(sub);
            }

            sub = Convert.ToInt32(comboBoxSub4.SelectedItem);
            if (sub >= 0)
            {
                subs.Add(sub);
            }

            var criteria = new NorthSearchCriteria
            {
                Subs = subs,
                From = dateTimePickerFrom.Value
            };

            return criteria;
        }

        private void DrawSouthLinear(object sender, EventArgs e)
        {
            var criteria = GetSouthSearchCriteria();

            var dic = GetSouthData(criteria);
            List<NumberData> list = dic.Select(p => new NumberData { Name = p.Key, Score = p.Value }).ToList();

            CreateRegressionChart(list);
        }

        private void DrawNorthLinear(object sender, EventArgs e)
        {

            var criteria = GetSearchCriteria();

            var dic = GetNorthData(criteria);
            List<NumberData> list = dic.Select(p => new NumberData { Name = p.Key, Score = p.Value }).ToList();

            CreateRegressionChart(list);
        }

        private void CreateRegressionChart(List<NumberData> students)
        {
            var chartArea = new ChartArea("MainArea");
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(chartArea);

            var pointSeries = new Series("Tần xuất")
            {
                ChartType = SeriesChartType.Point,
                MarkerSize = 12,
                MarkerStyle = MarkerStyle.Circle,
                Font = new Font("Arial", 16, FontStyle.Bold) // Font size 14
            };

            for (int i = 0; i < students.Count; i++)
            {
                pointSeries.Points.AddXY(i, students[i].Score);
                pointSeries.Points[i].Label = students[i].Name;
            }

            chart1.Series.Clear();
            chart1.Series.Add(pointSeries);

            // Tính hồi quy tuyến tính
            var xValues = Enumerable.Range(0, students.Count).Select(i => (double)i).ToList();
            var yValues = students.Select(s => s.Score).ToList();

            double xAvg = xValues.Average();
            double yAvg = yValues.Average();

            double numerator = xValues.Zip(yValues, (x, y) => (x - xAvg) * (y - yAvg)).Sum();
            double denominator = xValues.Sum(x => Math.Pow(x - xAvg, 2));

            double slope = numerator / denominator;
            double intercept = yAvg - slope * xAvg;

            // Series hồi quy tuyến tính
            var regressionSeries = new Series("Hồi quy tuyến tính")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Red,
                BorderWidth = 2
            };

            regressionSeries.Points.AddXY(0, intercept);
            regressionSeries.Points.AddXY(students.Count - 1, slope * (students.Count - 1) + intercept);

            chart1.Series.Add(regressionSeries);
        }
    }
}
