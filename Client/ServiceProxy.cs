using Common;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ServiceProxy
    {
        private ChannelFactory<IDQService> _channelFactory;

        public ServiceProxy()
        {
            _channelFactory = new ChannelFactory<IDQService>("DQService");
        }

        public dynamic Excute(Command cmd)
        {
            var server = _channelFactory.CreateChannel();

            return server.Excute(cmd);
        }

    }
}
