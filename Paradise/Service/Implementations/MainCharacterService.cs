using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    public class MainCharacterService : IMainCharacterService
    {
        private readonly IMainCharacterRepository mainCharacterRepository;

        public MainCharacterService()
        {
            var context = new WpfAppContext();
            mainCharacterRepository = new MainCharacterRepository(context);
        }

        public void AddMainCharacter(MainCharacter mainCharacter)
        {
            mainCharacterRepository.InsertMainCharacter(mainCharacter);
            mainCharacterRepository.Save();
        }

        public void Dispose()
        {
            mainCharacterRepository.Dispose();
        }

        public IEnumerable<MainCharacter> GetMainCharacters()
        {
            return mainCharacterRepository.FindAllMainCharacters().ToList();
        }

        public void RemoveMainCharacter(MainCharacter mainCharacter)
        {
            mainCharacterRepository.DeleteMainCharacter(mainCharacter.MainCharacterId);
            mainCharacterRepository.Save();
        }

        public void UpdateMainCharacter(MainCharacter mainCharacter)
        {
            mainCharacterRepository.UpdateMainCharacter(mainCharacter);
            mainCharacterRepository.Save();
        }
    }
}
