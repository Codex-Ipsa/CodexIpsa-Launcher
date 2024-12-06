using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes
{
    public class Http
    {
        public static String postJson(String url, String data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "application/json";
            req.Accept = "application/json";
            req.Method = "POST";

            using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
            {
                sw.Write(data);
            }

            var resp = (HttpWebResponse)req.GetResponse();
            var respString = "";
            using (StreamReader s = new StreamReader(resp.GetResponseStream()))
            {
                respString = s.ReadToEnd();
            }
            return respString;
        }

        public static String postUrl(String url, String data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            byte[] dataByte = Encoding.ASCII.GetBytes(data);
            req.ContentLength = dataByte.Length;

            using (Stream sw = req.GetRequestStream())
            {
                sw.Write(dataByte, 0, dataByte.Length);
            }

            var resp = (HttpWebResponse)req.GetResponse();
            var respString = new StreamReader(resp.GetResponseStream()).ReadToEnd();
            return respString;
        }

        public static String getJson(String url, Dictionary<String, String> headers)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "application/json";
            req.Accept = "application/json";
            req.Method = "GET";
            req.PreAuthenticate = true;

            foreach (KeyValuePair<String, String> k in headers)
            {
                req.Headers.Add(k.Key, k.Value);
            }

            var resp = (HttpWebResponse)req.GetResponse();
            var respString = "";
            using (StreamReader s = new StreamReader(resp.GetResponseStream()))
            {
                respString = s.ReadToEnd();
            }
            return respString;
        }
    }
}
