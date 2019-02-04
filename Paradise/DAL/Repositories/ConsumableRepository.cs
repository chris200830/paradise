using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    internal class ConsumableRepository : IConsumableRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public ConsumableRepository(WpfAppContext context)
        {
            _context = context;
        }

        public void DeleteConsumable(int consumableId)
        {
            var consumable = _context.Consumables.Find(consumableId);

            if (consumable == null)
                return;

            _context.Consumables.Remove(consumable);
        }

        public IEnumerable<Consumable> FindAllConsumables()
        {
            return _context.Consumables.ToList();
        }

        public Consumable GetConsumableById(int consumableId)
        {
            return _context.Consumables.Find(consumableId);
        }

        public void InsertConsumable(Consumable consumable)
        {
            _context.Consumables.Add(consumable);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateConsumable(Consumable consumable)
        {
            _context.Entry(consumable).State = EntityState.Modified;
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
