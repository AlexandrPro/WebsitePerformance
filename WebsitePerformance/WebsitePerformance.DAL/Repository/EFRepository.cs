using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WebsitePerformance.ContractsBetweenBLLandDAL.DAL;

namespace WebsitePerformance.DAL.Repository
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
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
                _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
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
