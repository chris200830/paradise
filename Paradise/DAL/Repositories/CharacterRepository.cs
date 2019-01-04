using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly WpfAppContext _context;
        private bool _disposed;

        public CharacterRepository(WpfAppContext context)
        {
            _context = context;
        }

        public void DeleteCharacter(int characterId)
        {
            var character = _context.Items.Find(characterId);

            if (character == null)
                return;

            _context.Items.Remove(character);
        }

        public IEnumerable<Character> FindAllCharacters()
        {
            return _context.Characters.ToList();
        }

        public Character GetCharacterById(int characterId)
        {
            return _context.Characters.Find(characterId);
        }

        public void InsertCharacter(Character character)
        {
            _context.Characters.Add(character);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCharacter(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
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
