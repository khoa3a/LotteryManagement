using BLL;
using BLL.Search;
using DAL;
using System.Windows.Forms.DataVisualization.Charting;


namespace LM
{
    public partial class LinearRegressionForm : Form
    {

        private NorthRepository northRepo;

        public LinearRegressionForm()
        {
            InitializeComponent();

            northRepo = RepositoryFactory.GetNorthRepo();

            InitializeEvent();

            InitializeData();
        }

        private void InitializeEvent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Paint += LinearRegressionForm_Paint;
        }

        private void InitializeData()
        {
            var data = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            PopulateComboBox(comboBoxSub1, data);
            PopulateComboBox(comboBoxSub2, data);
            PopulateComboBox(comboBoxSub3, data);
            PopulateComboBox(comboBoxSub4, data);

            //dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dateTimePickerFrom.Value = DateTime.Now.AddMonths(-6);
        }

        private void PopulateComboBox(ComboBox comboBox, List<int> models, bool addDefaultItem = true)
        {
            //var items = new List<ComboBoxItem>();
            comboBox.Items.Clear();
            if (addDefaultItem)
            {
                //var translation = GetTranslation();
                //var messages = GetTranslationMessages(translation);
                var defaultItem = "-1";

                //items.Add(new ComboBoxItem(defaultItem, ""));
                comboBox.Items.Add(defaultItem);
            }

            foreach (var model in models)
            {
                //string name = "";
                //string value = "";

                //if (model is User user)
                //{
                //    name = user.FullName;
                //    value = user.Id;
                //}                

                //items.Add(new ComboBoxItem(name, value));
                comboBox.Items.Add(model);
            }

            //comboBox.DisplayMember = "Name";
            //comboBox.ValueMember = "Value";
            //comboBox.DataSource = items;

            comboBox.SelectedIndex = 1;
        }

        private (double slope, double intercept) CalculateLinearRegression(List<double> xValues, List<double> yValues)
        {
            int n = xValues.Count;
            double sumX = xValues.Sum();
            double sumY = yValues.Sum();
            double sumXY = xValues.Zip(yValues, (x, y) => x * y).Sum();
            double sumX2 = xValues.Sum(x => x * x);

            double slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double intercept = (sumY - slope * sumX) / n;

            return (slope, intercept);
        }

        private Dictionary<string, int> GetNorthData(NorthSearchCriteria criteria)
        {
            //var criteria = new NorthSearchCriteria
            //{
            //    Subs = [1,3,7]
            //};



            var listNumbers = northRepo.SearchAll(criteria).Select(x => x.Sub4Number).ToList();

            Dictionary<string, int> result = listNumbers
                                    .GroupBy(x => x)
                                    .ToDictionary(g => g.Key.ToString(), g => g.Count());

            return result;
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

        private void button1_Click(object sender, EventArgs e)
        {

            var criteria = GetSearchCriteria();

            var dic = GetNorthData(criteria);
            List<NumberData> list = dic.Select(p => new NumberData { Name = p.Key, Score = p.Value }).ToList();

            CreateRegressionChart(list);

            //// Dữ liệu: ngày và nhiệt độ
            //List<double> days = new List<double> { 1, 2, 3, 4, 5, 6, 7 };
            //List<double> temps = new List<double> { 22, 24, 23, 25, 26, 27, 28 };

            //// Tính hệ số hồi quy
            //var (slope, intercept) = CalculateLinearRegression(days, temps);

            //// Cấu hình Chart
            //chart1.Series.Clear();
            //chart1.ChartAreas[0].AxisX.Title = "Ngày";
            //chart1.ChartAreas[0].AxisY.Title = "Nhiệt độ (°C)";

            //var tempSeries = chart1.Series.Add("Temperature");
            //tempSeries.ChartType = SeriesChartType.Point;
            //tempSeries.Color = Color.Blue;

            //var regressionSeries = chart1.Series.Add("Regression");
            //regressionSeries.ChartType = SeriesChartType.Line;
            //regressionSeries.Color = Color.Red;

            //// Vẽ dữ liệu và đường hồi quy
            //for (int i = 0; i < days.Count; i++)
            //{
            //    tempSeries.Points.AddXY(days[i], temps[i]);
            //}

            //// Vẽ đường hồi quy tuyến tính
            //double xMin = days.Min();
            //double xMax = days.Max();
            //double yMin = slope * xMin + intercept;
            //double yMax = slope * xMax + intercept;

            //regressionSeries.Points.AddXY(xMin, yMin);
            //regressionSeries.Points.AddXY(xMax, yMax);
        }

        private void CreateRegressionChart(List<NumberData> students)
        {
            // Danh sách học sinh và điểm
            //var students = new List<(string Name, double Score)>
            //{
            //    ("An", 7.5),
            //    ("Bình", 8.0),
            //    ("Cường", 6.5),
            //    ("Dũng", 9.0),
            //    ("Hà", 7.0)
            //};

            // Tạo Chart control
            //var chart = new Chart { Dock = DockStyle.Fill };
            var chartArea = new ChartArea("MainArea");
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(chartArea);
            //this.Controls.Add(chart1);

            // Series điểm học sinh
            var pointSeries = new Series("Tần xuất")
            {
                ChartType = SeriesChartType.Point,
                MarkerSize = 8
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

        //public static void ShowChart(List<NumberData> students)
        //{
        //    var plotModel = new PlotModel { Title = "Biểu đồ hồi quy điểm học sinh" };

        //    // Vẽ điểm học sinh
        //    var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
        //    for (int i = 0; i < students.Count; i++)
        //    {
        //        scatterSeries.Points.Add(new ScatterPoint(i, students[i].Score));
        //    }
        //    plotModel.Series.Add(scatterSeries);

        //    // Tính hồi quy tuyến tính
        //    var xValues = Enumerable.Range(0, students.Count).Select(i => (double)i).ToList();
        //    var yValues = students.Select(s => s.Score).ToList();

        //    double xAvg = xValues.Average();
        //    double yAvg = yValues.Average();

        //    double numerator = xValues.Zip(yValues, (x, y) => (x - xAvg) * (y - yAvg)).Sum();
        //    double denominator = xValues.Sum(x => Math.Pow(x - xAvg, 2));

        //    double slope = numerator / denominator;
        //    double intercept = yAvg - slope * xAvg;

        //    // Vẽ đường hồi quy
        //    var lineSeries = new LineSeries { Title = "Hồi quy tuyến tính", Color = OxyColors.Red };
        //    lineSeries.Points.Add(new DataPoint(0, intercept));
        //    lineSeries.Points.Add(new DataPoint(students.Count - 1, slope * (students.Count - 1) + intercept));
        //    plotModel.Series.Add(lineSeries);

        //    // Hiển thị biểu đồ
        //    var plotView = new PlotView { Model = plotModel, Dock = DockStyle.Fill };
        //    var form = new Form { Width = 800, Height = 600 };
        //    form.Controls.Add(plotView);
        //    Application.Run(form);
        //}
    }
}
