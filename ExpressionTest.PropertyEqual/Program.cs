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
            var p1 = new Person()
            {
                Name = "jxq",
                Age = 23
            };
            var p2 = new Person()
            {
                Name = "jxq",
                Age = 23
            };

            if (Operator<Person>.ObjectPropertyEqual(p1, p2))
            {
                Console.WriteLine("两个对象所有属性值都相等！");
            }

            Console.ReadKey();
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static class Operator<T>
        {
            private static readonly Func<T, T, bool> PropsEqual;

            public static bool ObjectPropertyEqual(T obj1, T obj2)
            {
                return PropsEqual.Invoke(obj1, obj2);
            }

            static Operator()
            {
                var x = Expression.Parameter(typeof(T), "x");
                var y = Expression.Parameter(typeof(T), "y");

                // 获取类型T上的可读Property
                var readableProps = from prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                    where prop.CanRead
                                    select prop;

                Expression combination = null;
                foreach (var readableProp in readableProps)
                {
                    var thisPropEqual = Expression.Equal(Expression.Property(x, readableProp),
                                                         Expression.Property(y, readableProp));

                    if (combination == null)
                    {
                        combination = thisPropEqual;
                    }
                    else
                    {
                        combination = Expression.AndAlso(combination, thisPropEqual);
                    }
                }

                if (combination == null)   // 如果没有需要比较的东西，直接返回false
                {
                    PropsEqual = (p1, p2) => false;
                }
                else
                {
                    PropsEqual = Expression.Lambda<Func<T, T, bool>>(combination, x, y).Compile();
                }
            }
        }
    }
}
