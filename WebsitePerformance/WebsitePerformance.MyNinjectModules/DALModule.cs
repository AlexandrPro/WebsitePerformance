using Ninject.Modules;
using WebsitePerformance.DAL.UnitOfWork;
using WebsitePerformance.ContractsBetweenBLLandDAL.DAL;

namespace WebsitePerformance.MyNinjectModules
{
    public class DALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
