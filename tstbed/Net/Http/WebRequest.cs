﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Net.Http
{
    static class WebRequestTst
    {
        public static void Test()
        {
            HttpClient client = new HttpClient();

            //HttpClient is preferred over HttpWebRequest due to async methods available out of the box and you would not have to worry about writing begin/end methods.
            void HttpClientTstAsync()
            {
                client.BaseAddress = new Uri("https://www.nytimes.com");
//                client.BaseAddress = new Uri("http://www.google.com/robots.txt");
                Task<string> str = client.GetStringAsync(""); //it is relative  //("https://www.nytimes.com");
                Utils.WriteDetailLine(str.Result);
            }

            async void GetAsync()
            {
                HttpResponseMessage msg = await client.GetAsync("");
                Utils.WriteDetailLine(msg.StatusCode.ToString());
            }

            Utils.WriteTopic("Web Request");
            WebRequest req = WebRequest.Create("http://www.contoso.com");
            WebResponse resp = req.GetResponse();
            Utils.WriteDetailLine(((HttpWebResponse)resp).StatusDescription);
            Stream strm = resp.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            string respFromServer = sr.ReadToEnd();
            Utils.WriteDetailLine(respFromServer);

            resp.Close(); //must close either resp or resp.stream (no harm in closing both)

            HttpClientTstAsync();
            GetAsync();
        }
    }
}
