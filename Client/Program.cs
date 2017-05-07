using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceReference1.DQServiceClient client = new ServiceReference1.DQServiceClient())
            {
                Console.WriteLine(client.Ping());
            }
            Console.ReadKey();
        }
    }
}
