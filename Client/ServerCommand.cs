using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServerCommand : Command
    {

        public override object Execute()
        {
            using (Client.ServiceReference1.DQServiceClient client = new Client.ServiceReference1.DQServiceClient())
            {
                return client.Excute(this);
            }

        }
    }
}
