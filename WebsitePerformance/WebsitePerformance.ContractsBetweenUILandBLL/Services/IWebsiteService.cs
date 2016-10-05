using System.Linq;
using WebsitePerformance.ContractsBetweenUILandBLL.DTO;

namespace WebsitePerformance.ContractsBetweenUILandBLL.Services
{
    public interface IWebsiteService
    {
        int TestWebsitePerformance(string url);
        IQueryable<LinkViewModel> GetLinks(int id);
    }
}
