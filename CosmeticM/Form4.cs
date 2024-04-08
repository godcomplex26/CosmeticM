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
using OxyPlot.WindowsForms;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CosmeticM
{
    public partial class Form4 : Form
    {
        private List<string> conditions = new List<string>();
        public enum PDataFields
        {
            datetime,
            ReactA_Temp,
            ReactB_Temp,
            ReactC_Temp,
            ReactD_Temp,
            ReactE_Temp,
            ReactF_Temp,
            ReactF_PH,
            Power,
            CurrentA,
            CurrentB,
            CurrentC
        }

        public Form4()
        {
            InitializeComponent();
            //new Form7();
            //listBox1.Items.AddRange(Utils.pdata);
            //listBox2.Items.AddRange(Utils.operators);

            DataManager.LoadP();
            // datetime between '2022-04-02' and '2022-04-09'
            loadCharts();
            DrawChart(chart1, "ReactA_Temp");

            //Form7 form7 = new Form7();
            //panel1.Controls.Add(form7);

        }

        //private void LoadFormControlsIntoPanel()
        //{
        //    Form7 form7 = new Form7();

        //    // 폼의 컨트롤을 패널에 추가
        //    while (form7.Controls.Count > 0)
        //    {
        //        Control control = form7.Controls[0];
        //        form7.Controls.RemoveAt(0);
        //        panel1.Controls.Add(control);
        //    }
        //}

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

            if (DataManager.datasP.Count > 0)
            {
                foreach ( var data in DataManager.datasP)
                {
                    series.Points.Add(
                        new OxyPlot.DataPoint(
                            DateTimeAxis.ToDouble(data.datetime),
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

        private void button1_Click(object sender, EventArgs e)
        {
            //string where = textBox1.Text.ToString();
            //DataManager.LoadP(where);
            //loadCharts();

            finalQueryGen();
            DataManager.LoadP(string.Join(" ", conditions));
            loadCharts();
        }

        private void loadCharts()
        {
            plotView1.Model = DrawGraph(PDataFields.ReactA_Temp.ToString());
            plotView2.Model = DrawGraph(PDataFields.ReactB_Temp.ToString());
            plotView3.Model = DrawGraph(PDataFields.ReactC_Temp.ToString());
            plotView4.Model = DrawGraph(PDataFields.ReactD_Temp.ToString());
            plotView5.Model = DrawGraph(PDataFields.ReactE_Temp.ToString());
            plotView6.Model = DrawGraph(PDataFields.ReactF_Temp.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string column = listBox1.SelectedItem.ToString();
            string op = listBox2.SelectedItem.ToString();
            string val = textBox4.Text;

            if (op.Equals("LIKE"))
                val += "%";
            if (column.Equals("datetime") || column.Equals("date"))
                val = $"'{val}'";

            string condition = $"{column} {op} {val}";
            if (IsValidWhereClause(condition))
            {
                if (conditions.Count != 0)
                {
                    if (conditions.Last().ToString().Equals("AND") || conditions.Last().ToString().Equals("OR"))
                    {
                        conditions.Add(condition);
                    }
                    else
                    {
                        conditions.Add("AND");
                        conditions.Add(condition);
                    }
                }
                else
                {
                    conditions.Add(condition);
                }
            }
            else
            {
                MessageBox.Show("조건 구성이 올바르지 않습니다.");
            }
            textBox4.Clear();
            condListRefresher();
        }

        public bool IsValidWhereClause(string whereClause)
        {
            string pattern = @"^(?:\s*\w+\s*(?:=|<>|>|<|>=|<=|LIKE|BETWEEN)\s*(?:'[^']*'|[\w\d%_\-\.]+(?:\.\d+)?)(?:\s*AND\s*(?:'[\w\d%_\-\.]+(?:\.\d+)?'))?(?:\s*ESCAPE\s*'\w')?(?:\s*AND\s*(?:'[\w\d%_\-\.]+(?:\.\d+)?'))?(?:\s*ESCAPE\s*'\w')?\s*(?:AND|OR)?\s*)*$";
            return Regex.IsMatch(whereClause, pattern, RegexOptions.IgnoreCase);
        }

        private void condListRefresher()
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(conditions.ToArray());
        }

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBox3.SelectedItem != null)
                {
                    string selectedItem = listBox3.SelectedItem.ToString();
                    conditions.Remove(selectedItem);
                    condListRefresher();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) // AND
        {
            if (conditions.Count != 0)
                conditions.Add("AND");
            condListRefresher();
        }

        private void button7_Click(object sender, EventArgs e) // OR
        {
            if (conditions.Count != 0)
                conditions.Add("OR");
            condListRefresher();
        }

        private void button3_Click(object sender, EventArgs e) // 날짜 입력
        {
            Point buttonLocation = button6.PointToScreen(Point.Empty);

            // MonthCalendar 컨트롤 생성
            MonthCalendar calendar = new MonthCalendar();

            // MonthCalendar의 속성 설정
            calendar.Location = new Point(buttonLocation.X, buttonLocation.Y + button1.Height);
            calendar.ShowToday = true;
            calendar.ShowTodayCircle = true;

            // MonthCalendar의 DateSelected 이벤트 처리
            calendar.DateSelected += (s, args) =>
            {
                // 선택한 날짜를 yyyy-MM-dd 형식으로 가져오기
                string selectedDate = args.Start.ToString("yyyy-MM-dd");

                // 선택한 날짜를 TextBox에 추가
                textBox4.Text = selectedDate;

                // MonthCalendar 제거
                this.Controls.Remove(calendar);
            };

            // MonthCalendar를 폼에 추가
            this.Controls.Add(calendar);

            // MonthCalendar를 맨 위로 가져오기
            calendar.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conditions.Clear();
            condListRefresher();
        }

        private void finalQueryGen()
        {
            int len = conditions.Count();

            if (len != 0)
            {
                if (conditions[len - 1].Equals("AND") || conditions[len - 1].Equals("OR"))
                {
                    conditions.RemoveAt(len - 1);
                }
            }
            condListRefresher();
        }
        private void DrawChart(Chart chart, string column)
        {
            if (DataManager.datasP.Count > 0)
            {
                foreach (var data in DataManager.datasP)
                {
                    chart.Series["Series1"].Points.AddXY(data.datetime,
                            Convert.ToDouble(data.GetType().GetProperty(column).GetValue(data)));
                }
            }
        }
    }
}
