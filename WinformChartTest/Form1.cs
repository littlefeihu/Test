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

namespace WinformChartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.chart1.Series[0].MarkerStyle = MarkerStyle.Triangle;
            this.chart1.Series[1].MarkerStyle = MarkerStyle.Circle;
            this.chart1.Series[2].MarkerStyle = MarkerStyle.Square;
            //this.chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            //this.chart1.ChartAreas[0].AxisY.IsStartedFromZero = true;

            this.chart1.Series[0].MarkerSize = 8;
            this.chart1.Series[1].MarkerSize = 8;
            this.chart1.Series[2].MarkerSize = 8;


            this.chart1.Series[0].MarkerColor = Color.Black;
            this.chart1.Series[1].MarkerColor = Color.Blue;
            this.chart1.Series[2].MarkerColor = Color.Orange;
            this.chart1.MouseClick += (sender, ex) =>
            {
                var HPoint = chart1.HitTest(ex.X, ex.Y);
                if (HPoint.PointIndex == -1 || HPoint.Series == null) return;

                HPoint.Series.Points[HPoint.PointIndex].LabelBackColor = Color.YellowGreen;
                if (HPoint.Series.Points[HPoint.PointIndex].Label == string.Empty)
                {
                    HPoint.Series.Points[HPoint.PointIndex].Label = HPoint.Series.Name + "(" + HPoint.Series.Points[HPoint.PointIndex].YValues[0].ToString() + ":" + HPoint.Series.Points[HPoint.PointIndex].XValue.ToString() + ")";
                }
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {

            chart1.SaveImage("ddd.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
        }
    }
}
