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
            XmlDocument doc = LoadSitemap(sitemapUrl);
            return SearchLinks(doc);
        }

        public List<string> SearchLinks(XmlDocument doc)
        {
            List<string> links = new List<string>();
            string link;
            foreach (XmlNode node in doc.DocumentElement)
            {
                link = string.Format(node.FirstChild.InnerText);
                if (link.Contains(".xml"))
                {
                    XmlDocument newDoc = LoadSitemap(link);
                    links.AddRange(SearchLinks(newDoc));
                }
                else
                {
                    links.Add(link);
                }
            }
            return links;
        }

        public XmlDocument LoadSitemap(string link)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(link);
            return doc;
        }
    }
}
