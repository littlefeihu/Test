using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    [ServiceContract]
    public interface IDQService
    {
        [OperationContract]
        bool Ping();
    }
    public class DQService : IDQService
    {
        public bool Ping()
        {
            return true;
        }
    }
}
