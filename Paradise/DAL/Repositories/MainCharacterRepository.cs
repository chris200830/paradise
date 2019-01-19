using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    public class MainCharacterRepository : IMainCharacterRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public MainCharacterRepository(WpfAppContext context)
        {
            _context = context;
        }

        public void DeleteMainCharacter(int mainCharacterId)
        {
            var mainCharacter = _context.MainCharacters.Find(mainCharacterId);

            if (mainCharacter == null)
                return;

            _context.MainCharacters.Remove(mainCharacter);
        }

        public IEnumerable<MainCharacter> FindAllMainCharacters()
        {
            return _context.MainCharacters.ToList();
        }

        public MainCharacter GetMainCharacterById(int mainCharacterId)
        {
            return _context.MainCharacters.Find(mainCharacterId);
        }

        public void InsertMainCharacter(MainCharacter mainCharacter)
        {
            _context.MainCharacters.Add(mainCharacter);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateMainCharacter(MainCharacter mainCharacter)
        {
            _context.Entry(mainCharacter).State = EntityState.Modified;
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
