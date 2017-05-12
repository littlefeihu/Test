using Common;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
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
