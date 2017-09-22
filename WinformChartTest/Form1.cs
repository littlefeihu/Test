using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinformChartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.chart1.Series[0].MarkerStyle = MarkerStyle.Triangle;
            //this.chart1.Series[1].MarkerStyle = MarkerStyle.Circle;
            //this.chart1.Series[2].MarkerStyle = MarkerStyle.Square;
            ////this.chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            ////this.chart1.ChartAreas[0].AxisY.IsStartedFromZero = true;

            //this.chart1.Series[0].MarkerSize = 8;
            //this.chart1.Series[1].MarkerSize = 8;
            //this.chart1.Series[2].MarkerSize = 8;


            //this.chart1.Series[0].MarkerColor = Color.Black;
            //this.chart1.Series[1].MarkerColor = Color.Blue;
            //this.chart1.Series[2].MarkerColor = Color.Orange;
            //this.chart1.MouseClick += (sender, ex) =>
            //{
            //    var HPoint = chart1.HitTest(ex.X, ex.Y);
            //    if (HPoint.PointIndex == -1 || HPoint.Series == null) return;

            //    HPoint.Series.Points[HPoint.PointIndex].LabelBackColor = Color.YellowGreen;
            //    if (HPoint.Series.Points[HPoint.PointIndex].Label == string.Empty)
            //    {
            //        HPoint.Series.Points[HPoint.PointIndex].Label = HPoint.Series.Name + "(" + HPoint.Series.Points[HPoint.PointIndex].YValues[0].ToString() + ":" + HPoint.Series.Points[HPoint.PointIndex].XValue.ToString() + ")";
            //    }
            //};

            //var p1 = new DataPoint();
            //p1.SetValueXY(10, 10);
            //p1.Label = "dd";
            //p1.LabelBackColor = Color.YellowGreen;
            //chart1.Series[0].Points.Add(p1);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            chart1.SaveImage("ddd.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
        }

        List<string> XData = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fName = openFileDialog1.FileName;
                var dt = NPOIHelper.Import(fName);

                if (checkBox1.Checked)
                {
                    dt.Columns.Add(new DataColumn { ColumnName = "上限" });
                    dt.Columns.Add(new DataColumn { ColumnName = "下限" });
                    foreach (DataRow row in dt.Rows)
                    {
                        row["上限"] = txtUpperlimit.Text;
                        row["下限"] = txtlowerlimit;
                    }
                }

                this.chart1.Series.Clear();

                Random random = new Random();

                int columnIndex = 0;
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.ColumnName != "卡片")
                    {
                        var seriesName = column.ColumnName;
                        var series = new Series();
                        series.ChartType = SeriesChartType.Line;
                        series.Name = seriesName;
                        this.chart1.Series.Add(series);
                        int rowIndex = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            var x = row["卡片"];
                            var y = row[seriesName];
                            var p1 = new DataPoint();
                            p1.SetValueXY(x, y);

                            //设置显示Label信息
                            if (rowIndex == columnIndex + 5 && (columnIndex == 2 || columnIndex == 4) ||
                                ((rowIndex == dt.Rows.Count - 10) && (columnIndex == 2 || columnIndex == 4))
                                || ((rowIndex == dt.Rows.Count / 2) && (columnIndex == 1 || columnIndex == 3)))
                            {
                                p1.Label = "\r\n" + seriesName + "\r\n 时间：" + x + "\r\n温度：" + y + "\r\n";
                                p1.LabelBackColor = Color.YellowGreen;
                            }
                            series.Points.Add(p1);
                            rowIndex += 1;
                        }
                    }
                    columnIndex += 1;
                }
            }
        }
    }
}
