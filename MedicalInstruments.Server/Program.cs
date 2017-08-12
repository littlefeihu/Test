using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstruments.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverUri = System.Configuration.ConfigurationManager.AppSettings["serveruri"];
            try
            {
                Console.WriteLine("server starting");
                WebApp.Start(serverUri);
                Console.WriteLine("server started");

                Console.ReadKey();
            }
            catch (TargetInvocationException)
            {
                Console.WriteLine("A server is already running at " + serverUri);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error happen when server starting" + ex.Message);

                Console.WriteLine("exception Info:" + ex.ToString());
            }
        }
    }
}
