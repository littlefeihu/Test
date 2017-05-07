using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHost
{
    class Program
    {
        private static System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(DQService));

        static void Main(string[] args)
        {
            try
            {
                host.Opening += (s, ex) => Console.WriteLine("服务正在启动！请稍后......");
                host.Opened += (s, ex) =>
                {
                    Console.WriteLine("服务正常启动！");
                };
                host.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("服务启动失败，" + ex.ToString());
            }
            Console.ReadKey();
        }
    }
}