using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    public class DialogueOptionRepository : IDialogueOptionRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public DialogueOptionRepository(WpfAppContext context)
        {
            _context = context;
        }

        public IEnumerable<DialogueOption> FindAllDialogueOptions()
        {
            return _context.DialogueOptions.ToList();
        }

        public DialogueOption GetDialogueOptionById(int dialogueOptionId)
        {
            return _context.DialogueOptions.Find(dialogueOptionId);
        }

        public void InsertDialogueOption(DialogueOption dialogueOption)
        {
            _context.DialogueOptions.Add(dialogueOption);
        }

        public void DeleteDialogueOption(int dialogueOptionId)
        {
            var dialogueOption = _context.DialogueOptions.Find(dialogueOptionId);

            if (dialogueOption == null)
                return;

            _context.DialogueOptions.Remove(dialogueOption);
        }

        public void UpdateDialogueOption(DialogueOption dialogueOption)
        {
            _context.Entry(dialogueOption).State = EntityState.Modified;
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
