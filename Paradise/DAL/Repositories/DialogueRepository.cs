using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    public class DialogueRepository : IDialogueRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public DialogueRepository(WpfAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Dialogue> FindAllDialogues()
        {
            return _context.Dialogues.ToList();
        }

        public Dialogue GetDialogueById(int dialogueId)
        {
            return _context.Dialogues.Find(dialogueId);
        }

        public void InsertDialogue(Dialogue dialogue)
        {
            _context.Dialogues.Add(dialogue);
        }

        public void DeleteDialogue(int dialogueId)
        {
            var dialogue = _context.Dialogues.Find(dialogueId);

            if (dialogue == null)
                return;

            _context.Dialogues.Remove(dialogue);
        }

        public void UpdateDialogue(Dialogue dialogue)
        {
            _context.Entry(dialogue).State = EntityState.Modified;
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
