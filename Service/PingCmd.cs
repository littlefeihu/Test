using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [DataContract(Namespace = "http://www.dqinfo.net/2017/dqinfo")]
    public class PingCmd : Command
    {
        [DataMember]

        public string IP { get; set; }
        public override object Execute()
        {
            return "1";
        }
    }
}
