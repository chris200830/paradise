using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IMainCharacterRepository : IDisposable
    {
        IEnumerable<MainCharacter> FindAllMainCharacters();
        MainCharacter GetMainCharacterById(int mainCharacterId);
        void InsertMainCharacter(MainCharacter mainCharacter);
        void DeleteMainCharacter(int mainCharacterId);
        void UpdateMainCharacter(MainCharacter mainCharacter);
        void Save();
    }
}