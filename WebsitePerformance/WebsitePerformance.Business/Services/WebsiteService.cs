using System.Collections.Generic;
using System.Linq;
using WebsitePerformance.ContractsBetweenBLLandDAL.DAL;
using WebsitePerformance.ContractsBetweenBLLandDAL.Entities;
using WebsitePerformance.ContractsBetweenUILandBLL.Services;
using WebsitePerformance.ContractsBetweenUILandBLL.DTO;
using WebsitePerformance.BLL.WebsiteAccess;
using System;

namespace WebsitePerformance.BLL.Services
{
    public class WebsiteService : IWebsiteService
    {
        IUnitOfWork db;

        public WebsiteService(IUnitOfWork uow)
        {
            this.db = uow;
        }

        private website SearchOrAddWebsiteOnDb(string _url)
        {
            //TODO: Add validation website
            website _website = null;
            try
            {
                _website = db.Websites.Find(w => (w.url == _url)).First();
            }
            catch { }
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
            link _link = null;
            try
            {
                _link = db.Links.Find(l => (l.site_id == website_id && l.url == _url)).First();
            }
            catch { }
            if (_link == null)
            {
                _link = new link() { site_id = website_id, url = _url, test_count = 0 };
                db.Links.Create(_link);
            }
            return _link;
        }

        private test AddTestOnDb(link _link, float testTime)
        {
            //TODO: Add validation test
            _link.test_count++;
            test _test = new test() { link_id = _link.id, number = _link.test_count, time = testTime };
            db.Tests.Create(_test);
            return _test;
        }

        public int TestWebsitePerformance(string url)
        {
            //TODO: Add validation LinkViewModel
            try
            {
                UrlRework(ref url);
                LinkResponseTime urlRT = new LinkResponseTime(url);
                urlRT.Measure();

                website Website = SearchOrAddWebsiteOnDb(url);

                //get all links from sitemap of website
                Sitemap sitemap = new Sitemap(url + "/sitemap.xml");
                List<string> links_url = sitemap.AllSiteLinks();

                //creation new tests
                foreach (string item in links_url)
                {
                    //add new link, if necessary
                    link _link = SearchOrAddLinkOnDb(Website.id, item);
                    //new test
                    LinkResponseTime linkRT = new LinkResponseTime(_link.url);
                    test _newTest = AddTestOnDb(_link, linkRT.Measure());
                }

                db.Save();

                return Website.id;
            } catch (Exception)
            {
                throw;
            }
        }

        void UrlRework(ref string url)
        {
            if (url.Contains("https://"))
            {
                int n = url.IndexOf("https://");
                url.Remove(n, "https://".Length);
                url = "http://" + url;
            }
            if (!url.Contains("http://"))
            {
                url = "http://" + url;
            }
            if (url.EndsWith(@"/"))
            {
                url.Remove(url.Length - 1, 1);
            }
        }


        public IQueryable<LinkViewModel> GetLinks(int id)
        {
            List<LinkViewModel> linkViewModels = new List<LinkViewModel>();
            

            List<link> links = new List<link>(db.Links.Find(l => (l.site_id == id)));
            foreach (link item in links)
            {
                LinkViewModel linkViewModel = new LinkViewModel();
                linkViewModel.Url = item.url;

                linkViewModel.NewTest = db.Tests.Find(t => (t.link_id == item.id && t.number == item.test_count)).First().time;

                int testCount = item.test_count;
                if (testCount == 1)
                    linkViewModel.LastTest = 0;
                else
                    linkViewModel.LastTest = db.Tests.Find(t => (t.link_id == item.id && t.number == item.test_count-1)).First().time;

                linkViewModels.Add(linkViewModel);
            }

            return linkViewModels.AsQueryable();
        }
    }
}
