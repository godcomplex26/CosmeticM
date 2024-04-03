﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataManager.Load();
            if (DataManager.datas.Count > 0)
            {
                dataGridView1.DataSource = DataManager.datas;
                dataGridView1.Columns["datetime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                // 소수점 이하 두 자리까지만 표시되도록 설정
                dataGridView1.Columns["ReactA_Temp"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["ReactB_Temp"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["ReactC_Temp"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["ReactD_Temp"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["ReactE_Temp"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["ReactF_Temp"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["ReactF_PH"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["Power"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["CurrentA"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["CurrentB"].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns["CurrentC"].DefaultCellStyle.Format = "N2";

                dataGridView2.DataSource = DataManager.qcData;
                dataGridView2.Columns["date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }
    }
}
