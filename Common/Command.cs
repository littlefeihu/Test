using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract(Namespace = "http://www.wantong-tech.net/2011/prisonecs")]
    public abstract class Command
    {
        /// <summary>
        /// 执行命令。
        /// </summary>
        /// <param name="provider">服务提供者。</param>
        /// <returns>执行结果。</returns>
        public abstract object Execute();

    }
}