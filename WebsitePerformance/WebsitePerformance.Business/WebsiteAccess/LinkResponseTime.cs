using System;
using System.Diagnostics;
using System.Net;

namespace WebsitePerformance.BLL.WebsiteAccess
{
    public class LinkResponseTime
    {
        string link;
        HttpWebRequest request;
        Stopwatch Watch;

        public LinkResponseTime(string link)
        {
            this.link = link;
            request = (HttpWebRequest)WebRequest.Create(link);
            Watch = new Stopwatch();
        }

        public float Measure()
        {
            try
            {
                Watch.Start();

                using (WebResponse response = request.GetResponse()) { }

                Watch.Stop();
                TimeSpan ts = Watch.Elapsed;
                return (float)ts.Seconds + (float)(ts.Milliseconds / 1000.0f);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
