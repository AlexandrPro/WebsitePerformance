using System;
using System.Diagnostics;
using System.Net;

namespace WebsitePerformance.BLL.WebsiteAccess
{
    public class LinkResponseTime
    {
        string link;
        HttpWebRequest request;
        Stopwatch stopWatch;

        public LinkResponseTime(string link)
        {
            this.link = link;
            request = (HttpWebRequest)WebRequest.Create(link);
            stopWatch = new Stopwatch();
        }

        public float Measure()
        {
            stopWatch.Start();
            using (WebResponse response = request.GetResponse())
            {
            }
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            float time = (float)ts.Seconds + (float)(ts.Milliseconds / 1000.0f);
            return time;
        }
    }
}
