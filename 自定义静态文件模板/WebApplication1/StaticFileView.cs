using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1
{
    public class StaticFileView : IView
    {
        public StaticFileView(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }


        public void Render(ViewContext viewContext, TextWriter writer)
        {
            byte[] buffer;
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);

            }
            writer.WriteLine(Encoding.UTF8.GetString(buffer));
        }
    }
}