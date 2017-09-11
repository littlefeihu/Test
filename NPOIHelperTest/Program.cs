using System;
using System.Collections.Generic;
using System.Data;
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

            foreach (DataColumn item in dt.Columns)
            {
                Console.WriteLine(item.ColumnName);
            }
            Console.ReadKey();
            Console.WriteLine(filePath);
        }
    }
}
