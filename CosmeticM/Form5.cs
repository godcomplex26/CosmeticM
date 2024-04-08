using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Common;
using ScottPlot.Statistics;

namespace CosmeticM
{
    public partial class Form5 : Form
    {
        Form7 form7 = new Form7();
        public enum QDataFields
        {
            date,
            weight,
            water,
            material,
            HSO,
            pH
        }

        public Form5()
        {
            InitializeComponent();
            ShowForm7AsChildForm();
            
            DataManager.LoadQ();
            DataManager.LoadP();
            // datetime between '2022-04-02' and '2022-04-09'
            //loadCharts();
            //DrawChart(chart1, "ReactA_Temp");
            DrawCharts();

        }

        private void ShowForm7AsChildForm()
        {
            form7.TopLevel = false;
            form7.FormBorderStyle = FormBorderStyle.None;
            form7.Dock = DockStyle.Fill;
            panel2.Controls.Add(form7);
            
            form7.Show();
        }

        private PlotModel DrawGraph(string column)
        {
            // 데이터 생성
            var model = new PlotModel { Title = column };
            //var model = new PlotModel ();
            var series = new LineSeries
            {
                Title = "Data",
                MarkerType = MarkerType.Circle
            };

            if (DataManager.datasQ.Count > 0)
            {
                foreach (var data in DataManager.datasQ)
                {
                    series.Points.Add(
                        new OxyPlot.DataPoint(
                            DateTimeAxis.ToDouble(data.date),
                            Convert.ToDouble(data.GetType().GetProperty(column).GetValue(data))
                            ));
                }
            }

            // 시리즈를 모델에 추가
            model.Series.Add(series);

            var dateTimeAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Date",
                IntervalType = OxyPlot.Axes.DateTimeIntervalType.Days,
                StringFormat = "yyyy-MM-dd"
            };
            model.Axes.Add(dateTimeAxis);

            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = column
            });

            // PlotView 컨트롤에 모델 할당
            return model;
        }

        private void loadCharts()
        {
            plotView1.Model = DrawGraph(QDataFields.weight.ToString());
            plotView2.Model = DrawGraph(QDataFields.water.ToString());
            plotView3.Model = DrawGraph(QDataFields.material.ToString());
            plotView4.Model = DrawGraph(QDataFields.HSO.ToString());
            plotView5.Model = DrawGraph(QDataFields.pH.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form7.finalQueryGen();
            DataManager.LoadQ(string.Join(" ", form7.conditions));
            loadCharts();
        }

        private void DrawChart(Chart chart, string column)
        {
            chart.Series[0].Name = column;
            if (DataManager.datasP.Count > 0)
            {
                foreach (var data in DataManager.datasP)
                {
                    chart.Series[column].Points.AddXY(data.datetime,
                            Convert.ToDouble(data.GetType().GetProperty(column).GetValue(data)));
                }
            }
        }

        private void DrawCharts()
        {
            for (int i = 1; i < Utils.qdata.Count(); i++)
            {
                Chart chart = new Chart();
                ChartArea chartArea = new ChartArea();
                Legend legend = new Legend();
                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();
                
                chart.Series.Add(Utils.qdata[i]);
                chart.ChartAreas.Add(chartArea);
                chart.Series[Utils.qdata[i]].ChartType = SeriesChartType.FastLine;

                chart.Name = "QData";
                legend.Name = "legend1";
                legend.Docking = Docking.Top;
                chartArea.Name = "ChartArea1";
                series.Name = Utils.qdata[i];

                series.ChartArea = chartArea.Name;
                series.Legend = "Legend1";

                int xSize = this.Size.Width / 2;
                int ySize = 200;
                int marginTop = 0;
                chart.Size = new Size(xSize, ySize);
                chart.Location = new Point(((i - 1) % 2)*xSize, marginTop + (((i - 1) / 2) * ySize));
                
                
                chart.Legends.Add(legend);

                
                //chart.Series[0].Name = Utils.qdata[i];
                if (DataManager.datasQ.Count > 0)
                {
                    foreach (var data in DataManager.datasQ)
                    {
                        chart.Series[Utils.qdata[i]].Points.AddXY(data.date,
                                Convert.ToDouble(data.GetType().GetProperty(Utils.qdata[i]).GetValue(data)));
                    }
                }
                panel1.Controls.Add(chart);
                groupBox1.SendToBack();
                //chart.Show();
            }
        }
    }
}
