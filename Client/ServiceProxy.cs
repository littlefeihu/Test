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

        public static readonly ServiceProxy Instance = new ServiceProxy();

        private static readonly ChannelFactory<IDQService> _channelFactory;

        static ServiceProxy()
        {
            _channelFactory = new ChannelFactory<IDQService>("DQService");
        }

        public dynamic Excute(Command cmd)
        {
            var server = _channelFactory.CreateChannel();
            return server.Excute(cmd);
        }
        public IDQService Channel
        {
            get
            {
                return _channelFactory.CreateChannel();
            }
        }

    }
}
