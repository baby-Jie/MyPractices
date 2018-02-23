using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyPractises.Comman
{
    class MyWebclient:WebClient
    {
        private int _timeout;

        public int TimeOut
        {
            get { return _timeout; }
            set
            {
                if (value <= 0)
                    _timeout = 1000;
                else
                    _timeout = value;
            }
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request =  (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = TimeOut;
            return request;
        }

    }
}
