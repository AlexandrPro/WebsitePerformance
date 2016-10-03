using System.Collections.Generic;
using System.Linq;
using WebsitePerformance.ContractsBetweenBLLandDAL.DAL;
using WebsitePerformance.ContractsBetweenBLLandDAL.Entities;
using WebsitePerformance.ContractsBetweenUILandBLL.Services;
using WebsitePerformance.ContractsBetweenUILandBLL.DTO;
using WebsitePerformance.BLL.WebsiteAccess;

namespace WebsitePerformance.Business.Services
{
    public class WebsiteService : IWebsiteService
    {
        IUnitOfWork db;
        string website_url { get; set; }

        public WebsiteService(IUnitOfWork uow)
        {
            this.db = uow;
        }

        private website SearchOrAddWebsiteOnDb(string _url) 
        {
            //TODO: Add validation website
            website _website = db.Websites.Find(w => (w.url == _url)).First();
            if (_website == null)
            {
                _website = new website() { url = _url };
                db.Websites.Create(_website);
            }

            return _website;
        }

        private link SearchOrAddLinkOnDb(int website_id, string _url)
        {
            //TODO: Add validation link
            link _link = db.Links.Find(l => (l.site_id == website_id && l.url == _url)).First();
            if (_link == null)
            {
                _link = new link() { site_id = website_id, url = _url, test_count = 0 };
            }
            return _link;
        }

        private test AddTestOnDb(link _link, float testTime)
        {
            //TODO: Add validation test
            _link.test_count++;
            test _test = new test() { link_id = _link.site_id, number = _link.test_count, time = testTime };
            return _test;
        }

        public IQueryable<LinkViewModel> TestWebsitePerformance(string url)
        {
            //TODO: Add validation LinkViewModel
            url = @"http://" + url;
            website Website = SearchOrAddWebsiteOnDb(url);

            //get all links from sitemap of website
            string SitemapUrl = url + "/sitemap.xml";
            Sitemap sitemap = new Sitemap(SitemapUrl);
            List<string> links_url = sitemap.AllSiteLinks();

            //creation LinksViewModel to output 
            List<LinkViewModel> linksViewModel = new List<LinkViewModel>();
            foreach(string item in links_url)
            {
                LinkViewModel linkViewModel = new LinkViewModel();
                //url
                link _link = SearchOrAddLinkOnDb(Website.id, item);
                linkViewModel.Url = _link.url;
                //last test
                test _lastTest = db.Tests.Find(t => (t.link_id == _link.id && t.number == _link.test_count)).First();
                if (_lastTest == null)
                    linkViewModel.LastTest = 0;
                else
                    linkViewModel.LastTest = _lastTest.time;
                //new test
                LinkResponseTime linkRT = new LinkResponseTime(_link.url);
                test _newTest = AddTestOnDb(_link, linkRT.Measure());
                linkViewModel.NewTest = _newTest.time;

                linksViewModel.Add(linkViewModel);
            }
            //save changes to db
            db.Save();

            return linksViewModel.AsQueryable();
        }
    }
}
