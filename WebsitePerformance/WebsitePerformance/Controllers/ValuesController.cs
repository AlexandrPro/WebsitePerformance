using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebsitePerformance.ContractsBetweenUILandBLL.Services;
using WebsitePerformance.ContractsBetweenUILandBLL.DTO;


namespace WebsitePerformance.Controllers
{
    public class ValuesController : ApiController
    {
        IWebsiteService websiteService;
        public ValuesController(IWebsiteService serv)
        {
            websiteService = serv;
        }

        [HttpGet]
        //public IEnumerable<LinkViewModel> GetLinks([FromBody]string url)
        public IEnumerable<LinkViewModel> GetLinks(string url)
        {
            return websiteService.TestWebsitePerformance(url);
        }

    }
}
