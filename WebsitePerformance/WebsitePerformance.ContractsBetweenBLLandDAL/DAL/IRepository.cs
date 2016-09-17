using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebsitePerformance.ContractsBetweenBLLandDAL.DAL
{
    public interface IRepository<T> where T: class 
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T FindById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
