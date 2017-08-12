using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedicalInstruments.Server.Controller
{
    public class InstallController : ApiController
    {
        [HttpGet]
        public string Feedback()
        {
            return "hi i'm from server";
        }
    }
}
