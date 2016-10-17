using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFVC.PowerShell;
using System.ComponentModel;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure your settings in the project settings
            var TfsServerUri = Properties.Settings.Default.TfsUri;

            TfsServer srv = new TfsServer(TfsServerUri);

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(srv))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(srv);
                Console.WriteLine("{0}={1}", name, value);
            }


            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            //srv.Connect();
        }
    }
}
