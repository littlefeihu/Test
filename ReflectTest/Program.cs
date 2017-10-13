using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Type t = typeof(Class1);
            System.Reflection.PropertyInfo[] properties = t.GetProperties();

            foreach (System.Reflection.PropertyInfo info in properties)
            {
                Console.WriteLine(GetDisplayName(t, info.Name));
            }

            Console.ReadKey();
        }
        public static string GetDisplayName(Type modelType, string propertyDisplayName)
        {
            var item = System.ComponentModel.TypeDescriptor.GetProperties(modelType)[propertyDisplayName].Attributes[typeof(System.ComponentModel.DisplayNameAttribute)] as System.ComponentModel.DisplayNameAttribute;
            if (item != null)
            {
                return item.DisplayName;
            }
            else
            {
                return item.ToString();
            }
        }
    }
    public class Class1
    {
        [DisplayName("冷库编号")]
        public string DocumentNumber { get; set; }
    }
}
