using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> FindAllEntities();
        T GetEntityById(int entityId);
        void InsertEntity(T entity);
        void DeleteEntity(T entity);
        void UpdateEntity(T entity);
        void Save();
    }
}