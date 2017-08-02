using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionTreeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person()
            {
                Name = "jxq",
                Age = 23
            };
            var shallowCopy = Operator<Person>.ShallowCopy(p);
            Console.WriteLine(shallowCopy.Name);
            shallowCopy.Name = "feichexia";
            Console.WriteLine(shallowCopy.Name);
            Console.WriteLine(p.Name);

            Console.ReadKey();
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static class Operator<T>
        {
            private static readonly Func<T, T> ShallowClone;

            public static T ShallowCopy(T sourcObj)
            {
                return ShallowClone.Invoke(sourcObj);
            }

            static Operator()
            {
                var origParam = Expression.Parameter(typeof(T), "orig");

                // for each read/write property on T, create a  new binding 
                // (for the object initializer) that copies the original's value into the new object 
                var setProps = from prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                               where prop.CanRead && prop.CanWrite
                               select (MemberBinding)Expression.Bind(prop, Expression.Property(origParam, prop));

                var body = Expression.MemberInit( // object initializer 
                    Expression.New(typeof(T)), // ctor 
                    setProps // property assignments 
                );

                ShallowClone = Expression.Lambda<Func<T, T>>(body, origParam).Compile();
            }
        }
    }
}