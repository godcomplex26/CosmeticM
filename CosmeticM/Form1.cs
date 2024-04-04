using OpenTK.Audio.OpenAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace CosmeticM
{
    public partial class Form1 : Form
    {
        /*        
                 // 데이터 표시 포맷, 시간은 초까지, 소수점은 두 자리까지
                public void Format()
                {
                    dataGridView1.Columns["datetime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dataGridView2.Columns["date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    // gridview1 소수점 이하 두 자리까지만 표시되도록 설정
                    string[] columns = { "ReactA_Temp", "ReactB_Temp", "ReactC_Temp", "ReactD_Temp", "ReactE_Temp",
                    "ReactF_Temp", "ReactF_PH", "Power", "CurrentA", "CurrentB","CurrentC"};
                    for (int i = 0; i < columns.Length; i++)
                    {
                        dataGridView1.Columns[columns[i]].DefaultCellStyle.Format = "N2";
                    }

                    // gridview2 소수점 이하 두 자리까지만 표시되도록 설정
                    string[] columns2 = { "weight", "water", "material", "HSO", "pH"};
                    for (int i = 0; i < columns2.Length; i++)
                    {
                        dataGridView2.Columns[columns2[i]].DefaultCellStyle.Format = "N2";
                    }

                    *//*
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
                    *//*
                }*/
        /*
                // 화면 리프레시
                public void reScreen()
                {   
                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = null;
                    DataManager.Load();
                    if (DataManager.datas.Count > 0)
                    {
                        dataGridView1.DataSource = DataManager.datas;
                        dataGridView2.DataSource = DataManager.datas2;
                        Format();
                    }
                }

                public void reScreen(string c1, string c2, string c3)
                {
                    dataGridView1.DataSource = null;
                    DataManager.Load(c1, c2, c3);
                    if (DataManager.datas.Count > 0)
                    {
                        dataGridView1.DataSource = DataManager.datas;
                        Format();
                    }
                }
        */
        /*
                // 랜덤 데이터 생성
                public PData makeRandom()
                {  Random rn = new Random();

                    PData data = new PData();
                    data.datetime = DateTime.Now;
                    data.ReactA_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
                    data.ReactB_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
                    data.ReactC_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
                    data.ReactD_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
                    data.ReactE_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
                    data.ReactF_Temp = rn.NextDouble() * (10.0 - 5.0) + 5.0;
                    data.ReactF_PH = rn.NextDouble() * (2.0 - 1.0) + 1.0;
                    data.Power = rn.NextDouble() * (1400.0 - 1300.0) + 1300.0;
                    data.CurrentA = rn.NextDouble() * (0.4 - 0.2) + 0.2;
                    data.CurrentB = rn.NextDouble() * (1.8 - 1.6) + 1.6;
                    data.CurrentC = rn.NextDouble() * (1.4 - 1.2) + 1.2;

                    return data;
                }
        */
        // 조건 초기화
        private List<string> conditions = new List<string>();
        public void resetCon()
        {
            Utils.reScreen(dataGridView1, dataGridView2);
            MessageBox.Show("조건이 초기화되었습니다.");
        }

        public Form1()
        {
            InitializeComponent();

            /* 너무 느려져서 기각
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // 열 너비 맞춤
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // 가운데 정렬
            */

            // label1.Text = "현재 선택 : ";
            Utils.reScreen(dataGridView1, dataGridView2);

            listBox1.Items.AddRange(Utils.pdata);
            listBox1.Items.AddRange(Utils.qdata);
            listBox2.Items.AddRange(Utils.operators);

        }

        // PData 데이터 조회
        private void button1_Click(object sender, EventArgs e)
        {
            string sql;

            finalQueryGen();

            sql = Utils.sqlQueryConverter(string.Join(" ", conditions));

            if (conditions.Count == 0)
            {
                sql = "-1";
            }

            Utils.reScreen(dataGridView1, "PData", sql);
        }

        // QData 데이터 조회
        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            finalQueryGen();
            sql = Utils.sqlQueryConverter(string.Join(" ", conditions));

            if (conditions.Count == 0)
            {
                sql = "-1";
            }

            Utils.reScreen(dataGridView2, "QData", sql);
        }
        /*
                // 셀 선택 시 할당되는 값
                string select = "";

                // 셀 선택 시 select에 datetime(PK) 할당
                private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                    PData  data = dataGridView1.CurrentRow.DataBoundItem as PData;
                    select = data.datetime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    label1.Text = "현재 선택 : " + select + " 기록 데이터";
                }
        */
        /*
                // 선택 데이터 삭제
                private void button2_Click(object sender, EventArgs e)
                {
                    // select와 동일한 datetime을 갖는 PData 객체 찾기
                    PData data = DataManager.datas.SingleOrDefault(x => x.datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") == select);
                    if (data != null)
                    {
                        DataManager.Delete(data);
                        label1.Text = "현재 선택 : ";
                        MessageBox.Show($"{select} 데이터가 삭제 되었습니다.");
                        select = "";
                        button1_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("해당하는 데이터가 없습니다.");
                    }
                }
        */
        /*
                // 테스트 데이터 n개 입력
                private void button3_Click(object sender, EventArgs e)
                {
                    int count = 1;
                    if (!textBox4.Text.Trim().Equals(""))
                    {
                        count = int.Parse(textBox4.Text);
                    }

                    // 확인 대화 상자 표시
                    DialogResult result = MessageBox.Show($"테스트 데이터를 {count}개 생성하시겠습니까?\n(이 작업은 수 초 내지 수 분이 소요될 수 있습니다.)", 
                        "생성", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    // 생성을 선택한 경우
                    if (result == DialogResult.OK)
                    {
                        // 테스트 데이터 생성 및 저장
                        for (int i = 0; i < count; i++)
                        {
                            PData random = makeRandom();
                            Thread.Sleep(100);
                            DataManager.Save(random);
                        }

                        // 데이터 그리드뷰 다시 불러오기
                        reScreen();

                        // 사용자에게 완료 메시지 표시
                        textBox4.Text = "";
                        MessageBox.Show($"테스트 데이터가 {count}개 생성 되었습니다.");
                    }
                    else // 취소를 선택한 경우
                    {
                        MessageBox.Show("테스트 데이터 생성이 취소 되었습니다.");
                    }
                }
        */

        // 조건 초기화
        private void button4_Click(object sender, EventArgs e)
        {
            resetCon();
            button1_Click(sender, e);
        }

        // 공정 데이터 관리
        private void ToolStrip1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            Utils.reScreen(dataGridView1, "PData");
        }

        // QC 데이터 관리
        private void ToolStrip2_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
            Utils.reScreen(dataGridView2, "QData");
        }


        // 공정 데이터 차트
        private void ToolStrip3_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        // QC 데이터 차트
        private void ToolStrip4_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }

        // 메인
        private void ToolStrip0_Click(object sender, EventArgs e)
        {
            Utils.reScreen(dataGridView1, dataGridView2);
        }

        //private void listBox1_DoubleClick(object sender, EventArgs e)
        //{
        //    if (listBox1.SelectedItem != null)
        //    {
        //        string selectedItem = listBox1.SelectedItem.ToString();
        //        // 선택된 아이템을 사용하여 원하는 동작 수행
        //        //textBox1.Text += selectedItem;

        //        int cursorPosition = textBox3.SelectionStart;
        //        textBox3.Text = textBox3.Text.Insert(cursorPosition, selectedItem);
        //        textBox3.SelectionStart = cursorPosition + selectedItem.Length;
        //        textBox3.Focus();
        //    }
        //}

        //private void listBox2_DoubleClick(object sender, EventArgs e)
        //{
        //    if (listBox2.SelectedItem != null)
        //    {
        //        string selectedItem = listBox2.SelectedItem.ToString();
        //        // 선택된 아이템을 사용하여 원하는 동작 수행
        //        //textBox1.Text += selectedItem;

        //        int cursorPosition = textBox3.SelectionStart;
        //        textBox3.Text = textBox3.Text.Insert(cursorPosition, selectedItem);
        //        textBox3.SelectionStart = cursorPosition + selectedItem.Length;
        //        textBox3.Focus();
        //    }
        //}

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
    }
}
