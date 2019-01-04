using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface ICharacterRepository :IDisposable
    {
        IEnumerable<Character> FindAllCharacters();
        Character GetCharacterById(int characterId);
        void InsertCharacter(Character character);
        void DeleteCharacter(int characterId);
        void UpdateCharacter(Character character);
        void Save();
    }
}