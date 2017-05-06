using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Test.WinAPI;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint BM_CLICK = 0xF5;
            const uint WM_SETTEXT = 0x000C;
            const uint WM_GETTEXT = 0x000D;

            var process = Process.Start(@"D:\BaiduNetdiskDownload\Jhmy\Jhmy\Epi.exe");

            IntPtr hwnd;
            while (true)
            {
                Thread.Sleep(1000);
                if (process.Responding)
                {
                    hwnd = WinAPI.FindWindow(null, "系统登录");
                    if (hwnd != IntPtr.Zero)
                    {
                        break;
                    }
                }
            }

            WinAPI.SetForegroundWindow(hwnd);

            IntPtr tpanelHwnd = WinAPI.FindWindowEx(hwnd, 0, "TPanel", null);
            if (tpanelHwnd != IntPtr.Zero)
            {
                var loginbtn = WinAPI.FindWindowEx(tpanelHwnd, 0, null, "登录");
                if (loginbtn != IntPtr.Zero)
                {
                    Console.WriteLine(loginbtn);
                }

                var password = WinAPI.FindWindowEx(tpanelHwnd, 0, "TEdit", null);
                if (password != IntPtr.Zero)
                {
                    Console.WriteLine(password);
                }
                WinAPI.SendMessage(password, WM_SETTEXT, IntPtr.Zero, "1234");
                var username = WinAPI.GetWindow(password, (int)WindowSearch.GW_HWNDNEXT);
                if (username != IntPtr.Zero)
                {
                    Console.WriteLine(username);
                }
                WinAPI.SendMessage(username, WM_SETTEXT, IntPtr.Zero, "system");

                const int buffer_size = 1024;
                StringBuilder buffer = new StringBuilder(buffer_size);

                WinAPI.GetMessage(username, WM_GETTEXT, buffer_size, buffer);
                Console.WriteLine(buffer.ToString());
                WinAPI.SendMessage(loginbtn, BM_CLICK, 0, 0);
            }
            else
            {
                Console.WriteLine("没有找到子窗口");
            }
            Console.ReadKey();
        }
    }
}
