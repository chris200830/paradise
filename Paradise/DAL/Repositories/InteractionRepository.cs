using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public InteractionRepository(WpfAppContext context)
        {
            _context = context;
        }

        public void DeleteInteraction(int interactionId)
        {
            var interaction = _context.Interactions.Find(interactionId);

            if (interaction == null)
                return;

            _context.Interactions.Remove(interaction);
        }

        public IEnumerable<Interaction> FindAllInteractions()
        {
            return _context.Interactions.ToList();
        }

        public Interaction GetInteractionById(int interactionId)
        {
            return _context.Interactions.Find(interactionId);
        }

        public void InsertInteraction(Interaction interaction)
        {
            _context.Interactions.Add(interaction);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateInteraction(Interaction interaction)
        {
            _context.Entry(interaction).State = EntityState.Modified;
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
