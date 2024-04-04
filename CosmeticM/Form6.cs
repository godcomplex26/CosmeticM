using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticM
{
    public partial class Form6 : Form
    {
        private Label label1;
        private ListBox listBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private MonthCalendar calendar1;
        private MonthCalendar calendar2;
        public static Dictionary<string, string> datas = new Dictionary<string, string>();
        public Form6()
        {
            InitializeComponent();
            dataDict(datas, Utils.pdata);
            dataDict(datas, Utils.qdata);

            label1 = new Label();
            label1.Text = "asdf";
            flowLayoutPanel1.Controls.Add(label1);

            addListBox(Utils.operators);
            listBox1.DoubleClick += operationSelect;
            //addCalendar();
            //addTextBox();
        }

        private void addListBox(string[] items)
        {
            listBox1 = new ListBox();
            listBox1.Items.AddRange(items);

            flowLayoutPanel1.Controls.Add(listBox1);
        }

        private ListBox addListBox(string[] items, string name)
        {
            ListBox listBox = new ListBox();
            listBox.Items.AddRange(items);

            flowLayoutPanel1.Controls.Add(listBox);
            return listBox;
        }

        private void addCalendar()
        {
            calendar1 = new MonthCalendar();

            flowLayoutPanel1.Controls.Add(calendar1);
        }

        private MonthCalendar addCalendar(string name)
        {
            MonthCalendar calendar = new MonthCalendar();
            calendar.Name = name;

            flowLayoutPanel1.Controls.Add(calendar);
            return calendar;
        }

        private void addTextBox()
        {
            textBox1 = new TextBox();

            flowLayoutPanel1.Controls.Add(textBox1);
        }

        private TextBox addTextBox(string name)
        {
            TextBox textBox = new TextBox();
            textBox.Name = name;

            flowLayoutPanel1.Controls.Add(textBox);
            return textBox;
        }

        private void operationSelect(object sender, EventArgs e)
        {
            string selectedItem = listBox1.SelectedItem.ToString();
            if (selectedItem.Equals("BETWEEN"))
            {
                typeSelect(label1.Text);
                typeSelect(label1.Text);
            }
            else
            {
                typeSelect(label1.Text);
            }
            
        }

        private void typeSelect(string item)
        {
            if (datas[item].Equals("calendar"))
            {
                addCalendar();
            }
            else
            {
                addTextBox();
            }
        }

        private void dataDict(Dictionary<string, string> dataDict, string[] datas)
        {
            foreach (string key in datas)
            {
                if (key.Equals("datetime") || key.Equals("date"))
                {
                    dataDict.Add(key, "calendar");
                }
                else
                {
                    dataDict.Add(key, "double");
                }
            }
        }
    }
}
