using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LoadMenuTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var i = double.Parse(Console.ReadLine());
                Console.WriteLine(i / 8.0);
            }


            XmlDocument doc = new XmlDocument();
            doc.Load("BugsBox.Pharmacy.AppClient.Menu_new.xml");

            List<FuncMapItem> Items = new List<FuncMapItem>();
            foreach (XmlNode node in doc.SelectNodes("/MenusGroup/Menu/Menu"))
            {


                FuncMapItem item = new FuncMapItem();
                Items.Add(item);
                item.Header = NodeTag.Create(node);
                Build(node, item);
            }

            foreach (var item in Items)
            {
                Console.WriteLine(item.Header.Title);
                foreach (var c in item.Children)
                {
                    Console.Write(c.Title + ",");
                }
                Console.WriteLine();
                Console.WriteLine("===========================================");
            }
            Console.ReadKey();
        }
        static void Build(XmlNode node, FuncMapItem item)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.HasChildNodes)
                {
                    Build(childNode, item);
                }
                else
                {
                    item.Children.Add(NodeTag.Create(childNode));
                }
            }
        }
    }

    public class FuncMapItem
    {
        public FuncMapItem()
        {
            Children = new List<NodeTag>();
        }
        public NodeTag Header { get; set; }

        public List<NodeTag> Children { get; set; }
    }
    public class NodeTag
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Params { get; set; }
        public string DockState { get; set; }
        public string ModuleKey { get; set; }

        public static NodeTag Create(XmlNode node)
        {
            return new NodeTag()
            {
                id = node.Attributes["id"].Value,
                Name = node.Attributes["Name"].Value,
                Params = node.Attributes["Params"].Value,
                DockState = node.Attributes["DockState"].Value,
                Title = node.Attributes["Title"].Value,
                ModuleKey = node.Attributes["ModuleKey"].Value
            };
        }
    }



}
