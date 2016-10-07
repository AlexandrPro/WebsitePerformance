using Ninject.Modules;
using WebsitePerformance.BLL.Services;
using WebsitePerformance.ContractsBetweenUILandBLL.Services;

namespace WebsitePerformance.MyNinjectModules
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWebsiteService>().To<WebsiteService>();
        }
    }
}