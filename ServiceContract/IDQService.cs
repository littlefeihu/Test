using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypeHelper))]
    [ServiceContract]
    public interface IDQService
    {
        [OperationContract]
        bool Ping();

        [OperationContract]
        dynamic Excute(Command cmd);
    }
}
