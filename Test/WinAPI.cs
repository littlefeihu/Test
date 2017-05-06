using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class WinAPI
    {
        //寻找目标进程窗口       
        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("USER32.DLL", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);
        //设置进程窗口到最前       
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        //模拟键盘事件         
        [DllImport("USER32.DLL")]
        public static extern void keybd_event(Byte bVk, Byte bScan, Int32 dwFlags, Int32 dwExtraInfo);
        public delegate bool CallBack(IntPtr hwnd, int lParam);
        [DllImport("USER32.DLL")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);
        //给CheckBox发送信息
        [DllImport("USER32.DLL", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, UInt32 wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int GetMessage(IntPtr hwnd, UInt32 wMsg, int wParam, StringBuilder lParam);

        //给Text发送信息
        [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);
        [DllImport("USER32.DLL")]
        public static extern IntPtr GetWindow(IntPtr hWnd, int wCmd);

        /// <summary>
        /// 查找窗体上控件句柄
        /// </summary>
        /// <param name="hwnd">父窗体句柄</param>
        /// <param name="lpszWindow">控件标题(Text)</param>
        /// <param name="bChild">设定是否在子窗体中查找</param>
        /// <returns>控件句柄，没找到返回IntPtr.Zero</returns>
        public static IntPtr FindWindowEx(IntPtr hwnd, string lpszWindow, bool bChild)
        {
            IntPtr iResult = IntPtr.Zero;
            // 首先在父窗体上查找控件
            iResult = FindWindowEx(hwnd,0, null, lpszWindow);
            // 如果找到直接返回控件句柄
            if (iResult != IntPtr.Zero) return iResult;
            // 如果设定了不在子窗体中查找
            if (!bChild) return iResult;
            // 枚举子窗体，查找控件句柄
            int i = EnumChildWindows(
            hwnd,
            (h, l) =>
            {
                IntPtr f1 = FindWindowEx(h, 0, null, lpszWindow);
                if (f1 == IntPtr.Zero)
                    return true;
                else
                {
                    iResult = f1;
                    return false;
                }
            },
            0);
            // 返回查找结果
            return iResult;
        }

        /// <summary>
        /// 输入回车
        /// </summary>
        private static void PrintEnter()
        {
            keybd_event(Convert.ToByte(13), 0, 0, 0);
            keybd_event(Convert.ToByte(13), 0, 2, 0);
        }
        public enum WindowSearch
        {
            GW_HWNDFIRST = 0, //同级别第一个
            GW_HWNDLAST = 1, //同级别最后一个
            GW_HWNDNEXT = 2, //同级别下一个
            GW_HWNDPREV = 3, //同级别上一个
            GW_OWNER = 4, //属主窗口
            GW_CHILD = 5 //子窗口}获取与指定窗口具有指定关系的窗口的句柄 
        }

    }
}
