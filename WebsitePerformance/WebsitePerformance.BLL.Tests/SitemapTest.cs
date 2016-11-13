using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebsitePerformance.BLL.WebsiteAccess;
using System.Xml;
using System.Collections.Generic;
using System.IO;

namespace WebsitePerformance.BLL.Tests
{
    [TestClass]
    public class SitemapTest
    {
        private Sitemap sm;
        private XmlDocument doc;
        private List<string> list;

        [TestInitialize]
        public void Setup()
        {
            sm = new Sitemap("");
            doc = new XmlDocument();
            list = new List<string>();
        }

        [TestMethod]
        public void SearchLinks_docOneLink_allLinks()
        {
            // arrange
            doc.LoadXml("<?xml version=\"1.0\"?> \n" +
                "<urlset> \n" +
                "<url> \n" +
                "<loc>http://test.com/first.html</loc> \n" +
                "</url> \n" +
                "</urlset> \n");
            // act
            list = sm.SearchLinks(doc);
            // assert
            Assert.AreEqual(list[0], "http://test.com/first.html");
        }

        [TestMethod]
        public void SearchLinks_docThreeLink_allLinks()
        {
            // arrange
            List<string> sample = new List<string>()
            {
                "http://test.com/first.html",
                "http://test.com/second.html",
                "http://test.com/third.html"
            };
            doc.LoadXml("<?xml version=\"1.0\" encoding=\"UTF - 8\"?> \n" +
                "<urlset> \n" +
                "<url> \n" +
                "<loc>" + sample[0] + "</loc> \n" +
                "</url> \n" +
                "<url> \n" +
                "<loc>" + sample[1] + "</loc> \n" +
                "</url> \n" +
                "<url> \n" +
                "<loc>" + sample[2] + "</loc> \n" +
                "</url> \n" +
                "</urlset> \n");
            // act
            list = sm.SearchLinks(doc);
            // assert
            
            Assert.IsTrue(list[0].Equals(sample[0]) &&
                list[1].Equals(sample[1]) &&
                list[2].Equals(sample[2]));
        }

        [TestMethod]
        public void SearchLinks_docZeroLink_emptyList()
        {
            // arrange
            doc.LoadXml("<?xml version=\"1.0\"?> \n" +
                "<urlset> \n" +
                "</urlset> \n");
            // act
            list = sm.SearchLinks(doc);
            // assert
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void SearchLinks_docWithLinkOnOtherXml_searchLinksInOtherXml()
        {
            // arrange
            string linkOnXml = "http://test.com/sitemap1.xml";
            doc.LoadXml("<?xml version=\"1.0\" encoding=\"UTF - 8\"?> \n" +
                "<urlset> \n" +
                "<url> \n" +
                "<loc>" + linkOnXml + "</loc> \n" +
                "</url> \n" +
                "</urlset> \n");
            // act
            try
            {
                list = sm.SearchLinks(doc);
            }
            catch (ArgumentException e)
            {
                // assert
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}
