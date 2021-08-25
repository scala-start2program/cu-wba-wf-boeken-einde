using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.Boeken.Lib.Services
{
    public class DBService
    {
        public static string GetCS()
        {
            string cstr = (string)System.Configuration.ConfigurationManager.AppSettings["constring"];
            return cstr;
        }
    }
}
