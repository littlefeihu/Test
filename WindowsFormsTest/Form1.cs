using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //启动notepad.exe 记事本程序，并在d:/下创建 或 打开 text_test.txt文件  
            System.Diagnostics.Process txt = System.Diagnostics.Process.Start(@"notepad.exe", @"d:/text_test.txt");
            txt.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //等待一秒，以便目标程序notepad.exe输入状态就绪  
            txt.WaitForInputIdle(1000);
            //如果目标程序 notepad.exe 没有停止响应，则继续  
            if (txt.Responding)
            {
                //开始写入内容  
                SendKeys.SendWait("-----下面的内容是外部程序自动写入-----/r/n");
                SendKeys.SendWait(this.textBox1.Text);     //将文本框内的内容写入  
                SendKeys.SendWait("{Enter}{Enter}");     //写入2个回车  
                SendKeys.SendWait("文档创建时间：");
                SendKeys.SendWait("{F5}");          //发送F5按键  
                SendKeys.SendWait("{Enter}");       //发送回车键  
                SendKeys.SendWait("^s");       //发送 Ctrl + s 键  
                SendKeys.SendWait("%{F4}");      // 发送 Alt + F4 键  
                MessageBox.Show("文件已经保存成功！");
              
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            const int BM_CLICK = 0xF5;
            IntPtr hwndCalc = WinAPI.FindWindow(null, "计算器"); //查找计算器的句柄  
            if (hwndCalc != IntPtr.Zero)
            {
                WinAPI.SetForegroundWindow(hwndCalc);

                IntPtr hwndThree = FindWindowEx(hwndCalc, IntPtr.Zero, null, "3"); //获取按钮3 的句柄  
          
                IntPtr hwndPlus = FindWindowEx(hwndCalc, IntPtr.Zero, null, "+");  //获取按钮 + 的句柄  
             
                IntPtr hwndTwo = FindWindowEx(hwndCalc, IntPtr.Zero, null, "2");  //获取按钮2 的句柄  
               
                IntPtr hwndEqual = FindWindowEx(hwndCalc, IntPtr.Zero, null, "="); //获取按钮= 的句柄  
           
                await Task.Delay(2000);
                WinAPI.SendMessage(hwndThree, BM_CLICK, 0, 0);
                await Task.Delay(2000);
                WinAPI.SendMessage(hwndPlus, BM_CLICK, 0, 0);
                await Task.Delay(2000);
                WinAPI.SendMessage(hwndTwo, BM_CLICK, 0, 0);
                await Task.Delay(2000);
                WinAPI.SendMessage(hwndEqual, BM_CLICK, 0, 0);
                await Task.Delay(2000);
                MessageBox.Show("你看到结果了吗？");
            }
            else
            {
                MessageBox.Show("没有启动 [计算器]");
            }
        }
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
    }

}
