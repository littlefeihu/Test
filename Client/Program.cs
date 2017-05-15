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

            PingCmd cmd = new PingCmd();
            var result = cmd.Execute();

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(result.Name);
            Console.WriteLine(result.ToString());

            Console.ReadKey();
        }
    }
}
