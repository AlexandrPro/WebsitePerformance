using System.Linq;
using WebsitePerformance.Contracts.DTO;

namespace WebsitePerformance.Contracts.Services
{
    interface IWebsiteService : IAddable<string>
    {
        IQueryable<LinkViewModel> TestWebsitePerformance(string url);
    }
}
