using System.Windows.Forms.DataVisualization.Charting;

namespace LM
{
    public partial class LinearRegressionForm : Form
    {
        public LinearRegressionForm()
        {
            InitializeComponent();

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
        }        

        public (double slope, double intercept) CalculateLinearRegression(List<double> xValues, List<double> yValues)
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

        private void button1_Click(object sender, EventArgs e)
        {


            // Dữ liệu: ngày và nhiệt độ
            List<double> days = new List<double> { 1, 2, 3, 4, 5, 6, 7 };
            List<double> temps = new List<double> { 22, 24, 23, 25, 26, 27, 28 };

            // Tính hệ số hồi quy
            var (slope, intercept) = CalculateLinearRegression(days, temps);

            // Cấu hình Chart
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Ngày";
            chart1.ChartAreas[0].AxisY.Title = "Nhiệt độ (°C)";

            var tempSeries = chart1.Series.Add("Temperature");
            tempSeries.ChartType = SeriesChartType.Point;
            tempSeries.Color = Color.Blue;

            var regressionSeries = chart1.Series.Add("Regression");
            regressionSeries.ChartType = SeriesChartType.Line;
            regressionSeries.Color = Color.Red;

            // Vẽ dữ liệu và đường hồi quy
            for (int i = 0; i < days.Count; i++)
            {
                tempSeries.Points.AddXY(days[i], temps[i]);
            }

            // Vẽ đường hồi quy tuyến tính
            double xMin = days.Min();
            double xMax = days.Max();
            double yMin = slope * xMin + intercept;
            double yMax = slope * xMax + intercept;

            regressionSeries.Points.AddXY(xMin, yMin);
            regressionSeries.Points.AddXY(xMax, yMax);
        }
    }
}
