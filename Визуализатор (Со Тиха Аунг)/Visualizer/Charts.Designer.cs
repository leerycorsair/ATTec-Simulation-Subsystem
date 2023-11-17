namespace Visualizer
{
    partial class Charts
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Charts));
            this.endChart = new System.Windows.Forms.Button();
            this.startChart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeChart = new System.Windows.Forms.ComboBox();
            this.parameterResource = new System.Windows.Forms.ComboBox();
            this.nameResource = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // endChart
            // 
            this.endChart.Location = new System.Drawing.Point(396, 424);
            this.endChart.Name = "endChart";
            this.endChart.Size = new System.Drawing.Size(87, 23);
            this.endChart.TabIndex = 17;
            this.endChart.Text = "Остановить";
            this.endChart.UseVisualStyleBackColor = true;
            this.endChart.Click += new System.EventHandler(this.endChart_Click);
            // 
            // startChart
            // 
            this.startChart.Location = new System.Drawing.Point(396, 392);
            this.startChart.Name = "startChart";
            this.startChart.Size = new System.Drawing.Size(87, 26);
            this.startChart.TabIndex = 16;
            this.startChart.Text = "Показать";
            this.startChart.UseVisualStyleBackColor = true;
            this.startChart.Click += new System.EventHandler(this.startChart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Тип графика";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Параметр ресурса";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Имя ресурса";
            // 
            // typeChart
            // 
            this.typeChart.FormattingEnabled = true;
            this.typeChart.Items.AddRange(new object[] {
            "Point",
            "FastPoint",
            "Bubble",
            "Line",
            "Spline",
            "StepLine",
            "FastLine",
            "Bar",
            "StackedBar",
            "StackedBar100",
            "Column",
            "StackedColumn",
            "StackedColumn100",
            "Area",
            "SplineArea",
            "StackedArea",
            "StackedArea100",
            "Pie",
            "Doughnut",
            "Stock",
            "Candlestick",
            "Range",
            "SplineRange",
            "RangeBar",
            "RangeColumn",
            "Radar",
            "Polar",
            "ErrorBar",
            "BoxPlot",
            "Renko",
            "ThreeLineBreak",
            "Kagi",
            "PointAndFigure",
            "Funnel",
            "Pyramid"});
            this.typeChart.Location = new System.Drawing.Point(229, 434);
            this.typeChart.Name = "typeChart";
            this.typeChart.Size = new System.Drawing.Size(121, 21);
            this.typeChart.TabIndex = 12;
            // 
            // parameterResource
            // 
            this.parameterResource.FormattingEnabled = true;
            this.parameterResource.Location = new System.Drawing.Point(229, 407);
            this.parameterResource.Name = "parameterResource";
            this.parameterResource.Size = new System.Drawing.Size(121, 21);
            this.parameterResource.TabIndex = 11;
            // 
            // nameResource
            // 
            this.nameResource.FormattingEnabled = true;
            this.nameResource.Location = new System.Drawing.Point(229, 380);
            this.nameResource.Name = "nameResource";
            this.nameResource.Size = new System.Drawing.Size(121, 21);
            this.nameResource.TabIndex = 10;
            this.nameResource.SelectedIndexChanged += new System.EventHandler(this.nameResource_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(34, 30);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(521, 335);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(588, 485);
            this.Controls.Add(this.endChart);
            this.Controls.Add(this.startChart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeChart);
            this.Controls.Add(this.parameterResource);
            this.Controls.Add(this.nameResource);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Charts";
            this.Text = "Графики";
            this.Load += new System.EventHandler(this.Charts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button endChart;
        private System.Windows.Forms.Button startChart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeChart;
        private System.Windows.Forms.ComboBox parameterResource;
        private System.Windows.Forms.ComboBox nameResource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
    }
}