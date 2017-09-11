using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOIHelperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "表头.xls");

            var dt = NPOIHelper.ImportTest(filePath);

            NPOIHelper.DataTableToExcel(dt, "dddd", filePath + "aa.xls");


            Console.WriteLine(filePath);
        }
    }
}
