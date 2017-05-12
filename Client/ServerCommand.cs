using Client;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [DataContract]
    public class ServerCommand : Command
    {

        public override object Execute()
        {
            return new ServiceProxy().Excute(this);
        }
    }
}
