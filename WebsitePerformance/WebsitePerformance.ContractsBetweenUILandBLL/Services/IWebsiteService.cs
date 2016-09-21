using System.Linq;
using WebsitePerformance.ContractsBetweenUILandBLL.DTO;

namespace WebsitePerformance.ContractsBetweenUILandBLL.Services
{
    public interface IWebsiteService
    {
        IQueryable<LinkViewModel> TestWebsitePerformance(string url);
    }
}
