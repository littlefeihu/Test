namespace WinformChartTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint25 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint26 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint27 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint28 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.5D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint29 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint30 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint31 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6D, -1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint32 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(7D, -2D);
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint33 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint34 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, -1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint35 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, -2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint36 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.5D, -3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint37 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, -2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint38 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, -3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint39 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6D, -6D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint40 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(7D, -4D);
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint41 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, -1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint42 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, -5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint43 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, -6D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint44 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.5D, -7D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint45 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, -8D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint46 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, -9D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint47 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6D, -5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint48 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(7D, -9D);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUpperlimit = new System.Windows.Forms.TextBox();
            this.txtlowerlimit = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 70);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsValueShownAsLabel = true;
            series4.Label = "#SERIESNAME;X:#VALX，Y：#VALY";
            series4.Legend = "Legend1";
            series4.Name = "变量1";
            series4.Points.Add(dataPoint25);
            series4.Points.Add(dataPoint26);
            series4.Points.Add(dataPoint27);
            series4.Points.Add(dataPoint28);
            series4.Points.Add(dataPoint29);
            series4.Points.Add(dataPoint30);
            series4.Points.Add(dataPoint31);
            series4.Points.Add(dataPoint32);
            series4.SmartLabelStyle.CalloutBackColor = System.Drawing.SystemColors.ActiveCaption;
            series4.ToolTip = "#LABEL#VAL;#VALY";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "变量2";
            series5.Points.Add(dataPoint33);
            series5.Points.Add(dataPoint34);
            series5.Points.Add(dataPoint35);
            series5.Points.Add(dataPoint36);
            series5.Points.Add(dataPoint37);
            series5.Points.Add(dataPoint38);
            series5.Points.Add(dataPoint39);
            series5.Points.Add(dataPoint40);
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "变量3";
            series6.Points.Add(dataPoint41);
            series6.Points.Add(dataPoint42);
            series6.Points.Add(dataPoint43);
            series6.Points.Add(dataPoint44);
            series6.Points.Add(dataPoint45);
            series6.Points.Add(dataPoint46);
            series6.Points.Add(dataPoint47);
            series6.Points.Add(dataPoint48);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(1308, 623);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(750, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "生成图片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "导入Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "上限值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "下限值";
            // 
            // txtUpperlimit
            // 
            this.txtUpperlimit.Location = new System.Drawing.Point(273, 21);
            this.txtUpperlimit.Name = "txtUpperlimit";
            this.txtUpperlimit.Size = new System.Drawing.Size(100, 21);
            this.txtUpperlimit.TabIndex = 5;
            this.txtUpperlimit.Text = "8";
            // 
            // txtlowerlimit
            // 
            this.txtlowerlimit.Location = new System.Drawing.Point(467, 21);
            this.txtlowerlimit.Name = "txtlowerlimit";
            this.txtlowerlimit.Size = new System.Drawing.Size(100, 21);
            this.txtlowerlimit.TabIndex = 6;
            this.txtlowerlimit.Text = "2";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(596, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 16);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "自动设置上限下限值";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtlowerlimit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUpperlimit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1308, 61);
            this.panel1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.770115F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.22988F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1314, 696);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 696);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUpperlimit;
        private System.Windows.Forms.TextBox txtlowerlimit;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

