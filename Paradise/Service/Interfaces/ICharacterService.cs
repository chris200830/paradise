using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface ICharacterService
    {
        void AddCharacter(Character character);
        void UpdateCharacter(Character character);
        void RemoveCharacter(Character character);
        void Dispose();
        IEnumerable<Character> GetCharacters();
    }
}