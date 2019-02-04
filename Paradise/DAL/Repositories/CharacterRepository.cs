using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    internal class CharacterRepository : ICharacterRepository
    {
        private readonly WpfAppContext context;
        private bool disposed;

        public CharacterRepository(WpfAppContext context)
        {
            this.context = context;
        }

        public void DeleteCharacter(int characterId)
        {
            var character = context.Characters.Find(characterId);

            if (character == null)
                return;

            context.Characters.Remove(character);
        }

        public IEnumerable<Character> FindAllCharacters()
        {
            return context.Characters.Include(c => c.CharacterDialogues).ToList();
        }

        public Character GetCharacterById(int characterId)
        {
            return context.Characters.Include(c => c.CharacterDialogues).ToList().Find(r => r.Id == characterId);
        }

        public void InsertCharacter(Character character)
        {
            context.Characters.Add(character);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCharacter(Character character)
        {
            context.Entry(character).State = EntityState.Modified;
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
