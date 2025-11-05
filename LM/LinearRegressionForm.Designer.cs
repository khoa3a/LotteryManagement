namespace LM
{
    partial class LinearRegressionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            comboBoxSub1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxSub2 = new ComboBox();
            label3 = new Label();
            comboBoxSub3 = new ComboBox();
            label4 = new Label();
            comboBoxSub4 = new ComboBox();
            button1 = new Button();
            label5 = new Label();
            dateTimePickerFrom = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(12, 116);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(2118, 1197);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // comboBoxSub1
            // 
            comboBoxSub1.FormattingEnabled = true;
            comboBoxSub1.Location = new Point(210, 40);
            comboBoxSub1.Name = "comboBoxSub1";
            comboBoxSub1.Size = new Size(93, 28);
            comboBoxSub1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(145, 43);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 2;
            label1.Text = "SUB1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 43);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 4;
            label2.Text = "SUB2";
            // 
            // comboBoxSub2
            // 
            comboBoxSub2.FormattingEnabled = true;
            comboBoxSub2.Location = new Point(418, 40);
            comboBoxSub2.Name = "comboBoxSub2";
            comboBoxSub2.Size = new Size(93, 28);
            comboBoxSub2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(581, 46);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 6;
            label3.Text = "SUB3";
            // 
            // comboBoxSub3
            // 
            comboBoxSub3.FormattingEnabled = true;
            comboBoxSub3.Location = new Point(646, 43);
            comboBoxSub3.Name = "comboBoxSub3";
            comboBoxSub3.Size = new Size(93, 28);
            comboBoxSub3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(799, 46);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 8;
            label4.Text = "SUB4";
            // 
            // comboBoxSub4
            // 
            comboBoxSub4.FormattingEnabled = true;
            comboBoxSub4.Location = new Point(864, 43);
            comboBoxSub4.Name = "comboBoxSub4";
            comboBoxSub4.Size = new Size(93, 28);
            comboBoxSub4.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(1345, 18);
            button1.Name = "button1";
            button1.Size = new Size(239, 76);
            button1.TabIndex = 9;
            button1.Text = "LINEAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1003, 46);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 11;
            label5.Text = "FROM";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.CustomFormat = "dd/MM/yyyy";
            dateTimePickerFrom.Location = new Point(1058, 43);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(200, 27);
            dateTimePickerFrom.TabIndex = 12;
            // 
            // LinearRegressionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2142, 1325);
            Controls.Add(dateTimePickerFrom);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(comboBoxSub4);
            Controls.Add(label3);
            Controls.Add(comboBoxSub3);
            Controls.Add(label2);
            Controls.Add(comboBoxSub2);
            Controls.Add(label1);
            Controls.Add(comboBoxSub1);
            Controls.Add(chart1);
            Name = "LinearRegressionForm";
            Text = "LinearRegressionForm";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox comboBoxSub1;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxSub2;
        private Label label3;
        private ComboBox comboBoxSub3;
        private Label label4;
        private ComboBox comboBoxSub4;
        private Button button1;
        private Label label5;
        private DateTimePicker dateTimePickerFrom;
    }
}