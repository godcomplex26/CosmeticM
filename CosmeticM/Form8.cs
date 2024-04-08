using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CosmeticM
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            //Chart chart = new Chart();
            //int xSize = this.Size.Width / 2;
            //int ySize = 200;
            //chart.Size = new Size(xSize, ySize);
            //chart.Series.Add(new Series("test"));
            //string n = chart.Series[0].Name;
            //chart.Series[0].Name = Utils.qdata[1];
            //chart.Series[Utils.qdata[1]].Points.AddXY(xSize, ySize);
            //Controls.Add(chart);
            //chart.Show();

            Chart chart = new Chart();
            int xSize = this.Size.Width / 2;
            int ySize = 200;
            chart.Size = new Size(xSize, ySize);

            // 차트의 위치 설정
            chart.Location = new Point(10, 10);

            // 차트의 Anchor 속성 설정
            chart.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            chart.Series.Add(new Series("test"));
            string n = chart.Series[0].Name;
            chart.Series[0].Name = Utils.qdata[1];
            chart.Series[Utils.qdata[1]].Points.AddXY(xSize, ySize);

            Controls.Add(chart);
        }

        //private void ShowForm7AsChildForm()
        //{
        //    Form7 form7 = new Form7();
        //    form7.TopLevel = false;
        //    form7.FormBorderStyle = FormBorderStyle.None;
        //    form7.Dock = DockStyle.Fill;
        //    this.Controls.Add(form7);
        //    form7.Show();
        //}
    }
}
