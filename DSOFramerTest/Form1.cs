﻿using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSOFramerTest
{
    public partial class Form1 : Form
    {
        //鼠标按下坐标（control控件的相对坐标）
        Point mouseDownPoint = Point.Empty;
        //显示拖动效果的矩形
        System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty;
        //是否正在拖拽
        bool isDrag = false;
        public Form1()
        {
            InitializeComponent();
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDrag_Paint);
            var wordtemplate = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "冷库验证报告模板.doc");
            axFramerControl1.Titlebar = false;
            axFramerControl1.Menubar = false;
            axFramerControl1.Toolbars = true;
            axFramerControl1.Open(wordtemplate);
            this.SizeChanged += Form1_SizeChanged;
            //button2.MouseDown += new MouseEventHandler(control_MouseDown);
            //button2.MouseMove += new MouseEventHandler(control_MouseMove);
            //button2.MouseUp += new MouseEventHandler(control_MouseUp);
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            axFramerControl1.Refresh();
        }

        void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = e.Location;
                //记录控件的大小
                rect = button2.Bounds;
            }
        }
        void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                //重新设置rect的位置，跟随鼠标移动
                rect.Location = getPointToForm(new Point(e.Location.X - mouseDownPoint.X, e.Location.Y - mouseDownPoint.Y));
                this.Refresh();

            }
        }
        void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isDrag)
                {
                    isDrag = false;
                    //移动control到放开鼠标的地方
                    button2.Location = rect.Location;
                    this.Refresh();
                }
                reset();
            }
        }
        //重置变量
        private void reset()
        {
            mouseDownPoint = Point.Empty;
            rect = System.Drawing.Rectangle.Empty;
            isDrag = false;
        }
        //窗体重绘
        private void FormDrag_Paint(object sender, PaintEventArgs e)
        {
            if (rect != System.Drawing.Rectangle.Empty)
            {
                if (isDrag)
                {//画一个和Control一样大小的黑框
                    e.Graphics.DrawRectangle(Pens.Black, rect);
                }
                else
                {
                    e.Graphics.DrawRectangle(new Pen(this.BackColor), rect);
                }
            }
        }
        //把相对与control控件的坐标，转换成相对于窗体的坐标。
        private Point getPointToForm(Point p)
        {
            return this.PointToClient(button2.PointToScreen(p));
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            axFramerControl1.Close();

            axFramerControl1.Dispose();
        }
        //第一步：注册AxFramerControl
        public bool RegControl()
        {
            try
            {

                Assembly thisExe = Assembly.GetExecutingAssembly();
                System.IO.Stream myS = thisExe.GetManifestResourceStream("NameSpaceName.dsoframer.ocx");

                string sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\dsoframer.ocx";
                ProcessStartInfo psi = new ProcessStartInfo("regsvr32", "/s " + sPath);
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DocumentClass wordDoc = axFramerControl1.ActiveDocument as DocumentClass;

            Microsoft.Office.Interop.Word.Application wordApp = wordDoc.Application;

            Microsoft.Office.Interop.Word.Range r = wordDoc.Paragraphs[15].Range;

            wordApp.Selection.Bookmarks.Add("ddee1");

            wordApp.Selection.Font.Color = WdColor.wdColorRed;
            wordApp.Selection.TypeText("ddee1");

            axFramerControl1.Save();

        }

        ///// <summary>
        ///// 替换标签下
        ///// </summary>
        ///// <param name="_sMark"></param>
        ///// <param name="_sReplaceText"></param>
        ///// <param name="_IsD">替换后是否突出显示</param>
        ///// <returns></returns>
        //public bool WordReplace(string _sMark, string _sReplaceText, bool _IsD)
    }
}