using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public class LogHelper
    {
        public static void Log(string format, params object[] parms)
        {
            try
            {
                string msg = string.Format(format, parms);
                using (StreamWriter sw = new StreamWriter(File.Open("log.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ":" + msg);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
