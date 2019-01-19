using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    public class InteractableObjectRepository : IInteractableObjectRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public InteractableObjectRepository(WpfAppContext context)
        {
            _context = context;
        }

        public IEnumerable<InteractableObject> FindAllInteractableObjects()
        {
            return _context.InteractableObjects.ToList();
        }

        public InteractableObject GetInteractableObjectById(int interactableObjectId)
        {
            return _context.InteractableObjects.Find(interactableObjectId);
        }

        public void InsertInteractableObject(InteractableObject interactableObject)
        {
            _context.InteractableObjects.Add(interactableObject);
        }

        public void DeleteInteractableObject(int interactableObjectId)
        {
            var interactableObject = _context.InteractableObjects.Find(interactableObjectId);

            if (interactableObject == null)
                return;

            _context.InteractableObjects.Remove(interactableObject);
        }

        public void UpdateInteractableObject(InteractableObject interactableObject)
        {
            _context.Entry(interactableObject).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
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
