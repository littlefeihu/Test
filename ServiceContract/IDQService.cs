using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        [OperationContract]
        Entity GetEntityById(Entity entity);
        [OperationContract]
        void Insert(Entity entity);
        [OperationContract]
        void Update(Entity entity);
        [OperationContract]

        void Delete(Entity entity);
        [OperationContract]
        IQueryable<User> Query(Entity entity, XElement predicate);

    }
}
