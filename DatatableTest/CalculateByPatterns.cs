using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dq.Info.Core
{
    public class CalculateByPatterns
    {
        //"最低值(列头关键字)",
        //"最高值(列头关键字)",
        //"平均值(列头关键字)",
        //"时间点(状态列名称)",
        //"布点数量(列头关键字)",
        //"开始值(状态列名称)",
        //"时间间隔(状态列名称，以逗号分隔)",
        //"平均差值(列头关键字，以逗号分隔)",
        //"探头编号(列头关键字)"

        const string AvgStr = "均匀";
        const string EnvironmentStr = "环境";
        public static string GetValue(ComputeInfo computeInfo, DataTable table)
        {
            string result = "";
            List<string> columns = new List<string>();
            foreach (DataColumn item in table.Columns)
            {
                columns.Add(item.ColumnName);
            }
            var fullColumnName = "";
            switch (computeInfo.CalKeyword)
            {
                case "最低值":
                    fullColumnName = columns.FirstOrDefault(o => o.Contains(computeInfo.CustomContent));
                    result = table.AsEnumerable().Select(t => double.Parse(t.Field<string>(fullColumnName))).Min().ToString();
                    break;
                case "最高值":
                    fullColumnName = columns.FirstOrDefault(o => o.Contains(computeInfo.CustomContent));

                    result = table.AsEnumerable().Select(t => double.Parse(t.Field<string>(fullColumnName))).Max().ToString();
                    break;
                case "平均值":
                    fullColumnName = columns.FirstOrDefault(o => o.Contains(computeInfo.CustomContent));
                    result = table.AsEnumerable().Select(t => double.Parse(t.Field<string>(fullColumnName))).Average().ToString();
                    break;
                case "时间点":
                    result = table.Compute("max(卡片)", "状态列 = '" + computeInfo.CustomContent + "' ").ToString();
                    break;
                case "布点数量":
                    if (computeInfo.CustomContent == AvgStr || computeInfo.CustomContent == EnvironmentStr)
                    {//均匀布点和环境布点数量
                        result = columns.Where(o => o.Contains(computeInfo.CustomContent)).Count().ToString();
                    }
                    else
                    {
                        //特殊布点数量
                        //总布点数 等于总列数减去卡片 状态列 终端1 终端2
                        var totalCount = columns.Count - 4;

                        var avgCount = columns.Where(o => o.Contains(AvgStr)).Count();
                        var environmentCount = columns.Where(o => o.Contains(EnvironmentStr)).Count();

                        result = (totalCount - avgCount - environmentCount).ToString();
                    }
                    break;
                case "开始值":
                    DataRow[] rows = table.Select("状态列 = '" + computeInfo.CustomContent + "'");
                    List<double> values = new List<double>();
                    string columnName = null;
                    foreach (DataColumn dataColumn in table.Columns)
                    {
                        columnName = dataColumn.ColumnName;
                        if (columnName == "卡片" || columnName == "状态列" || columnName == "终端1" || columnName == "终端2")
                        {
                            continue;
                        }
                        values.Add(double.Parse(rows[0][columnName].ToString()));
                    }
                    result = values.Max().ToString();
                    break;
                case "时间间隔":
                    var arr = computeInfo.CustomContent.Split(',');
                    var time1 = DateTime.Parse(table.Compute("max(卡片)", "状态列 = '" + arr[0] + "' ").ToString());
                    var time2 = DateTime.Parse(table.Compute("max(卡片)", "状态列 = '" + arr[1] + "' ").ToString());
                    TimeSpan ts = time2.Subtract(time1);
                    result = ts.TotalMinutes.ToString();
                    break;
                case "平均差值":
                    var arr1 = computeInfo.CustomContent.Split(',');

                    var name1 = columns.FirstOrDefault(o => o.Contains(arr1[0]));
                    var name2 = columns.FirstOrDefault(o => o.Contains(arr1[1]));

                    var q = from m in table.AsEnumerable().Select(t => new
                    {
                        v1 = double.Parse(t.Field<string>(name1)),
                        v2 = double.Parse(t.Field<string>(name2))
                    })

                            select Math.Abs(m.v1 - m.v2);

                    result = q.Average().ToString();
                    break;
                case "探头编号":

                    result = columns.FirstOrDefault(o => o.Contains(computeInfo.CustomContent)).ToString();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
