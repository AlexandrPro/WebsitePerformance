using System;
using System.Diagnostics;
using System.Net;

namespace WebsitePerformance.Business.WebsiteAccess
{
    public class LinkResponseTime
    {
        string link;
        HttpWebRequest request;
        Stopwatch stopWatch;

        LinkResponseTime(string link)
        {
            this.link = link;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            Stopwatch stopWatch = new Stopwatch();
        }

        public double Measure(string link)
        {
            stopWatch.Start();
            using (WebResponse response = request.GetResponse())
            {
            }
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            double time = (double)ts.Seconds + (double)ts.Milliseconds / 1000.0;
            return time;
        }
    }
}
