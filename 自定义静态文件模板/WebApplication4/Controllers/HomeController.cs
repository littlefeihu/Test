using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ImagePath(string id)
        {
            string path = Server.MapPath("/images/" + id + ".jpeg");
            return File(path, "image/jpeg");
        }

        public ActionResult ImagePath1(string id)
        {
            string path = Server.MapPath("/images/" + id + ".jpeg");
            return File(path, "image/jpeg", "下载");
        }


        public ActionResult ImageContent(string id)
        {
            string path = Server.MapPath("/images/" + id + ".jpeg");
            byte[] heByte = null;
            using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                int fsLen = (int)fsRead.Length;
                heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
            }
            return File(heByte, "image/jpeg");
        }
        public ActionResult ImageStream(string id)
        {
            string path = Server.MapPath("/images/" + id + ".jpeg");
            FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read);

            return File(fsRead, "image/jpeg");

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}