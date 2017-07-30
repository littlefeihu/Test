using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1
{
    public class StaticFileViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return this.FindView(controllerContext, partialViewName, null, useCache);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");
            var result = InternalFindView(controllerContext, viewName, controllerName);
            return result;
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {

        }
        private ViewEngineResult InternalFindView(ControllerContext controllerContext, string viewName, string controllerName)
        {
            string[] searchlocations = new string[] {
                 string.Format("~/Views/{0}/{1}.shtml",controllerName,viewName),
                 string.Format("~/Views/Shared/{0}.shtml",viewName)
            };
            string filename = controllerContext.HttpContext.Request.MapPath(searchlocations[0]);
            if (File.Exists(filename))
            {
                return new ViewEngineResult(new StaticFileView(filename), this);
            }
            filename = controllerContext.HttpContext.Request.MapPath(searchlocations[1]);
            if (File.Exists(filename))
            {
                return new ViewEngineResult(new StaticFileView(filename), this);
            }
            return new ViewEngineResult(searchlocations);

        }
    }
}