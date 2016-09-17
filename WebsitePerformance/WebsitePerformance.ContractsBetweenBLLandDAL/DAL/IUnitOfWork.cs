using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsitePerformance.ContractsBetweenBLLandDAL.Entities;

namespace WebsitePerformance.ContractsBetweenBLLandDAL.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<website> Websites { get; }
        IRepository<link> Links { get; }
        IRepository<test> Tests { get; }
        void Save();
    }
}
