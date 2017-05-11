using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypeHelper))]
    [ServiceContract]
    public interface IDQService
    {
        [OperationContract]
        bool Ping();

        [OperationContract]
        object Excute(Command cmd);
    }

    public class DQService : IDQService
    {
        public object Excute(Command cmd)
        {
            return cmd.Execute();
        }

        public bool Ping()
        {
            return true;
        }
    }
}
