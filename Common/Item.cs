using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class Book
    {
        [DataMember]

        public List<Item> Items { get; set; }
    }
    [DataContract]
    public class Bookshelf
    {

        [DataMember]

        public List<Book> Books { get; set; }
    }
}
