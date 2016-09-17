using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebsitePerformance.ContractsBetweenBLLandDAL.Entities;
using WebsitePerformance.ContractsBetweenBLLandDAL.DAL;
using System.Linq.Expressions;
using System.Threading;

namespace WebsitePerformance.DAL
{
    class EFRepository<T> : IRepository<T> where T: class
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _entities;
        
        public EFRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Where(o => true);
        }
    }
}
