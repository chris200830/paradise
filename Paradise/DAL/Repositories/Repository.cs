using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Database;
using DAL.Interfaces;

namespace DAL.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public Repository(WpfAppContext context)
        {
            _context = context;
        }

        public void DeleteEntity(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAllEntities()
        {
            return _context.Set<T>();
        }

        public T GetEntityById(int entityId)
        {
            return _context.Set<T>().Find(entityId);
        }

        public void InsertEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
