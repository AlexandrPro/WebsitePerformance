using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using WebsitePerformance.ContractsBetweenBLLandDAL.DAL;

namespace WebsitePerformance.DAL.Repository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _entities;

        public EFRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public T Add(T entity)
        {
            var newEntity = _entities.Create();
            _entities.Add(newEntity);
            _context.Entry(newEntity).CurrentValues.SetValues(entity);
            return newEntity;
        }

        public void Update(T entity)
        {
            SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Monitor.Enter(LockContainer.LockObject);
                var entity = FindById(id);
                _entities.Remove(entity);
            }
            finally
            {
                Monitor.Exit(LockContainer.LockObject);
            }
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> data;
            try
            {
                Monitor.Enter(LockContainer.LockObject);
                data = _entities.Where(o => true);
            }
            finally
            {
                Monitor.Exit(LockContainer.LockObject);
            }
            return data;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> data;
            try
            {
                Monitor.Enter(LockContainer.LockObject);
                data = _entities.Where(expression);
            }
            finally
            {
                Monitor.Exit(LockContainer.LockObject);
            }
            return data;
        }

        public T Get(int id)
        {
            T data;
            try
            {
                Monitor.Enter(LockContainer.LockObject);
                data = _entities.Find(id);
            }
            finally
            {
                Monitor.Exit(LockContainer.LockObject);
            }

            return data;
        }

        public void SaveChanges()
        {
            try
            {
                Monitor.Enter(LockContainer.LockObject);
                _context.SaveChanges();
            }
            finally
            {
                Monitor.Exit(LockContainer.LockObject);
            }
        }
    }
}
