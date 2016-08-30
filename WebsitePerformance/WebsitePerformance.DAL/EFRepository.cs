using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebsitePerformance.Contracts.DAL;
using System.Linq.Expressions;
using System.Threading;

namespace WebsitePerformance.DAL
{
    public static class LockContainer
    {
        public static readonly object LockObject = new object();
    }

    class EFRepository<T> : IRepository<T> where T: class
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
            try
            {
                Monitor.Enter(LockContainer.LockObject);
                var newEntity = _entities.Create();
                _entities.Add(newEntity);
                _context.Entry(newEntity).CurrentValues.SetValues(entity);
                //_context.SaveChanges();
                return newEntity;
            }
            finally
            {
                Monitor.Exit(LockContainer.LockObject);
            }
        }

        public void Delete(int id)
        {
            try
            {
                Monitor.Enter(LockContainer.LockObject);
                var entity = FindById(id);
                _entities.Remove(entity);
                //_context.SaveChanges();
            }
            finally
            {
                Monitor.Exit(LockContainer.LockObject);
            }
        }

        public void Update(T entity)
        {
            //TODO: Test, rework if need 
            SaveChanges();
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

        public T FindById(int id)
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
