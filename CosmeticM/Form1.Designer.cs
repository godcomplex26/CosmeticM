﻿namespace CosmeticM
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button30 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStrip0 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip2 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip3 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip4 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1080, 485);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1080, 404);
            this.dataGridView2.TabIndex = 15;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1145, 222);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(191, 21);
            this.textBox3.TabIndex = 20;
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(1280, 170);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(56, 46);
            this.button30.TabIndex = 19;
            this.button30.Text = "자리수늘리기";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(1218, 170);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(56, 46);
            this.button20.TabIndex = 18;
            this.button20.Text = "자리수줄이기";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1096, 511);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "공정 데이터";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Location = new System.Drawing.Point(12, 667);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1096, 430);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "QC 데이터";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip0,
            this.ToolStrip1,
            this.ToolStrip2,
            this.ToolStrip3,
            this.ToolStrip4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1531, 25);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "데이터 관리";
            // 
            // ToolStrip0
            // 
            this.ToolStrip0.Name = "ToolStrip0";
            this.ToolStrip0.Size = new System.Drawing.Size(39, 22);
            this.ToolStrip0.Text = "[메인]";
            this.ToolStrip0.Click += new System.EventHandler(this.ToolStrip0_Click);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(107, 22);
            this.ToolStrip1.Text = "[공정 데이터 관리]";
            this.ToolStrip1.Click += new System.EventHandler(this.ToolStrip1_Click);
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Size = new System.Drawing.Size(100, 22);
            this.ToolStrip2.Text = "[QC 데이터 관리]";
            this.ToolStrip2.Click += new System.EventHandler(this.ToolStrip2_Click);
            // 
            // ToolStrip3
            // 
            this.ToolStrip3.Name = "ToolStrip3";
            this.ToolStrip3.Size = new System.Drawing.Size(67, 22);
            this.ToolStrip3.Text = "[공정 차트]";
            this.ToolStrip3.Click += new System.EventHandler(this.ToolStrip3_Click);
            // 
            // ToolStrip4
            // 
            this.ToolStrip4.Name = "ToolStrip4";
            this.ToolStrip4.Size = new System.Drawing.Size(60, 22);
            this.ToolStrip4.Text = "[QC 차트]";
            this.ToolStrip4.Click += new System.EventHandler(this.ToolStrip4_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1531, 119);
            this.panel1.TabIndex = 22;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1145, 286);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(285, 23);
            this.progressBar1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1548, 597);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button20);
            this.Name = "Form1";
            this.Text = "화장품 생산 관리 프로그램";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip menuStrip1;
        private System.Windows.Forms.ToolStripLabel ToolStrip1;
        private System.Windows.Forms.ToolStripLabel ToolStrip2;
        private System.Windows.Forms.ToolStripLabel ToolStrip3;
        private System.Windows.Forms.ToolStripLabel ToolStrip4;
        private System.Windows.Forms.ToolStripLabel ToolStrip0;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
