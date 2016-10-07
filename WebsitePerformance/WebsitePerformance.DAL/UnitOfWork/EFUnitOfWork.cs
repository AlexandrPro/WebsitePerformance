using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsitePerformance.ContractsBetweenBLLandDAL.DAL;
using WebsitePerformance.DAL.EF;
using WebsitePerformance.DAL.Repository;
using WebsitePerformance.ContractsBetweenBLLandDAL.Entities;


namespace WebsitePerformance.DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private WebsitePerformanceModel db;
        private EFRepository<website> websiteRepository;
        private EFRepository<link> linkRepository;
        private EFRepository<test> testRepository;

        public EFUnitOfWork()
        {
            db = new WebsitePerformanceModel();
        }

        public IRepository<website> Websites
        {
            get
            {
                if (websiteRepository == null)
                    websiteRepository = new EFRepository<website>(db);
                return websiteRepository;
            }
        }

        public IRepository<link> Links
        {
            get
            {
                if (linkRepository == null)
                    linkRepository = new EFRepository<link>(db);
                return linkRepository;
            }
        }

        public IRepository<test> Tests
        {
            get
            {
                if (testRepository == null)
                    testRepository = new EFRepository<test>(db);
                return testRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
