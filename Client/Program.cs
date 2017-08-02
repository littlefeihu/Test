using Common;
using ExpressionSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            PingCmd cmd = new PingCmd();
            var result = cmd.Execute();

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }


            //ServiceProxy.Instance.Channel.Insert(new User { Id = 4, Name = "allen", CreateOn = DateTime.Now, });



            var user = (User)ServiceProxy.Instance.Channel.GetEntityById(new User { Id = 4 });
            Console.WriteLine(user.Name);

            user.Name = "J";
            ServiceProxy.Instance.Channel.Update(user);
            user = (User)ServiceProxy.Instance.Channel.GetEntityById(new User { Id = 4 });
            Console.WriteLine(user.Name);

            ServiceProxy.Instance.Channel.Delete(user);

            user = (User)ServiceProxy.Instance.Channel.GetEntityById(new User { Id = 4 });
            Console.WriteLine(user.Name);

            Expression<Func<User, bool>> predicate = (u) => u.Id == 4;

            var xmlPredicate = SerializeHelper.SerializeExpression(predicate);

            var query = ServiceProxy.Instance.Channel.Query(new User(), xmlPredicate) as IQueryable<User>;

            foreach (var item in query.ToList())
            {
                Console.WriteLine(item.Name + ":" + item.Id);
            }



            Console.ReadKey();
        }
    }
}
