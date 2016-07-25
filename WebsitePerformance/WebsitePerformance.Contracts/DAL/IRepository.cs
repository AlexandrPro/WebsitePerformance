using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebsitePerformance.Contracts.DAL
{
    interface IRepository<T> where T: class 
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
