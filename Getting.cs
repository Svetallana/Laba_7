using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace KM_7
{
    public class Getting
    {
        HttpWebRequest _req;
        string _adr;
        public string Responce { get; set; }
        public Getting(string address)
        {
            _adr = address;
        }
        public void Run()
        {
            _req = (HttpWebRequest)WebRequest.Create(_adr);
            _req.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_req.GetResponse();
                var stream = response.GetResponseStream();

                if (stream != null)
                {
                    Responce = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n[Не вдалося отримати данi, спробуйте ще раз]");
            }
        }

    }
}