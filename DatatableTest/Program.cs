using Dq.Info.Core;
using NPOIHelperTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatatableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "空载.xls");

            var dt = NPOIHelper.Import(filePath);

            //"最低值(列头关键字)",
            //"最高值(列头关键字)",
            //"平均值(列头关键字)",
            //"时间点(状态列名称)",
            //"布点数量(列头关键字)",
            //"开始值(状态列名称)",
            //"时间间隔(状态列名称，以逗号分隔)",
            //"平均差值(列头关键字，以逗号分隔)",
            //"探头编号(列头关键字)"

            List<ComputeInfo> infos = new List<ComputeInfo> {

                  new ComputeInfo{ CustomContent="出风口1", CalKeyword="最低值" },
                  new ComputeInfo{ CustomContent="出风口2", CalKeyword="最高值" },
                  new ComputeInfo{ CustomContent="出风口3", CalKeyword="平均值" },
                  new ComputeInfo{ CustomContent="开门开始", CalKeyword="时间点" },
                  new ComputeInfo{ CustomContent="开门结束", CalKeyword="时间点" },
                  new ComputeInfo{ CustomContent="均匀", CalKeyword="布点数量" },
                  new ComputeInfo{ CustomContent="特殊", CalKeyword="布点数量" },
                  new ComputeInfo{ CustomContent="环境", CalKeyword="布点数量" },
                  new ComputeInfo{ CustomContent="开门开始", CalKeyword="开始值" },
                  new ComputeInfo{ CustomContent="开门开始,开门结束", CalKeyword="时间间隔" },
                  new ComputeInfo{ CustomContent="探头1,终端1", CalKeyword="平均差值" },
                  new ComputeInfo{ CustomContent="探头2,终端2", CalKeyword="平均差值" },
                  new ComputeInfo{ CustomContent="探头1", CalKeyword="探头编号" },
            };


            foreach (var item in infos)
            {
                var val = CalculateByPatterns.GetValue(item, dt);
                Console.WriteLine(val);
            }
            Console.ReadKey();
            Console.WriteLine(filePath);
        }
    }
}
