using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    internal class InteractiveObjectRepository : IInteractiveObjectRepository
    {
        private bool disposed;

        private readonly WpfAppContext context;

        public InteractiveObjectRepository(WpfAppContext context)
        {
            this.context = context;
        }

        public IEnumerable<InteractiveObject> FindAllInteractiveObjects()
        {
            return context.InteractiveObjects.Include(c => c.Interactions).ToList();
        }

        public InteractiveObject GetInteractiveObjectById(int interactiveObjectId)
        {
            return context.InteractiveObjects.Include(c => c.Interactions).ToList().Find(r => r.Id == interactiveObjectId);
        }

        public void InsertInteractiveObject(InteractiveObject interactiveObject)
        {
            context.InteractiveObjects.Add(interactiveObject);
        }

        public void DeleteInteractiveObject(int interactiveObjectId)
        {
            var interactiveObject = context.InteractiveObjects.Find(interactiveObjectId);

            if (interactiveObject == null)
                return;

            context.InteractiveObjects.Remove(interactiveObject);
        }

        public void UpdateInteractiveObject(InteractiveObject interactiveObject)
        {
            context.InteractiveObjects.Attach(interactiveObject);
            context.Entry(interactiveObject).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
