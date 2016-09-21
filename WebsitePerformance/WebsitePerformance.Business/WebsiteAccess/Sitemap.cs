using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;

namespace WebsitePerformance.BLL.WebsiteAccess
{
    public class Sitemap
    {
        string sitemapUrl;

        public Sitemap(string url)
        {
            sitemapUrl = url;
        }
        
        public List<string> AllSiteLinks()
        {
            return SearchLinks(sitemapUrl);
        }

        private List<string> SearchLinks(string sitemapLink)
        {
            //load sitemap.xml from URL
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(sitemapLink);
            XmlDocument sitemap = new XmlDocument();
            sitemap.Load(stream);

            //search all links on XML file stream
            List<string> links = new List<string>();
            string link;
            foreach (XmlNode node in sitemap.DocumentElement)
            {
                link = string.Format(node.FirstChild.InnerText);
                if (link.Contains(".xml"))
                {
                    links.AddRange(SearchLinks(link));
                }
                else
                {
                    links.Add(link);
                }
            }
            return links;
        }
    }
}
