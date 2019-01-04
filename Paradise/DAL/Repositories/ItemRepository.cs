using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public ItemRepository(WpfAppContext context)
        {
            _context = context;
        }

        public void DeleteItem(int itemId)
        {
            var item = _context.Items.Find(itemId);

            if (item == null)
                return;

            _context.Items.Remove(item);
        }

        public IEnumerable<Item> FindAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int itemId)
        {
            return _context.Items.Find(itemId);
        }

        public void InsertItem(Item item)
        {
            _context.Items.Add(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
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
