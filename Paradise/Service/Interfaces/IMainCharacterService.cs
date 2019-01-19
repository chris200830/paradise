using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface IMainCharacterService
    {
        void AddMainCharacter(MainCharacter mainCharacter);
        void UpdateMainCharacter(MainCharacter mainCharacter);
        void RemoveMainCharacter(MainCharacter mainCharacter);
        void Dispose();
        IEnumerable<MainCharacter> GetMainCharacters();
    }
}