using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebsitePerformance.ContractsBetweenUILandBLL.Services;
using WebsitePerformance.ContractsBetweenUILandBLL.DTO;
//using System.Web.Mvc.IDependencyResolver;

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
        public IEnumerable<LinkViewModel> GetLinks(int id)
        {
            return websiteService.GetLinks(id);
        }

        [HttpPost]
        public int TestWebsite([FromBody]string url)
        {
            try
            {
                return websiteService.TestWebsitePerformance(url);
            }
            catch (Exception e)
            {
                /*
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    ReasonPhrase = e.Message
                };*/
                
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
                response.ReasonPhrase = e.Message;
                response.Content = new StringContent(e.Message, System.Text.Encoding.UTF8);
                HttpResponseException httpEx = new HttpResponseException(response);
                throw httpEx;

                /*
                 * Обязательно прописать в Global.asax  :
                 * GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;
                 */
            }
        }

    }
}
