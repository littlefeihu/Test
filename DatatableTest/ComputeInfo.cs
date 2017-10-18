using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dq.Info.Core
{
    public class ComputeInfo
    {
        /// <summary>
        /// 指示 数值来自于Excel
        /// </summary>
        public bool IsFromExcel { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string CalKeyword { get; set; }

        /// <summary>
        /// 自定义内容
        /// </summary>
        public string CustomContent { get; set; }

        /// <summary>
        /// 书签名称
        /// </summary>
        public string BookmarkName { get; set; }


    }
}
