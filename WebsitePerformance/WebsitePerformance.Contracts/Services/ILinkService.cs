using WebsitePerformance.Contracts.DTO;

namespace WebsitePerformance.Contracts.Services
{
    interface ILinkService : IAddable<string>
    {
       LinkViewModel TestLinkPerformance(string url);
    }
}
