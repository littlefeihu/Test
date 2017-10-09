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

namespace DSOFramerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var wordtemplate = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "冷库验证报告模板.doc");
            axFramerControl1.Titlebar = false;
            axFramerControl1.Menubar = false;
            axFramerControl1.Toolbars = false;
            axFramerControl1.Open(wordtemplate);
        }


    }
}
