using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [DataContract]
    public class PingCmd : Service.ServerCommand
    {
        [DataMember]

        public string IP { get; set; }


    }
}
