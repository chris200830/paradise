using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository characterRepository;

        public CharacterService()
        {
            var context = new WpfAppContext();
            characterRepository = new CharacterRepository(context);
        }

        public void AddCharacter(Character character)
        {
            characterRepository.InsertCharacter(character);
            characterRepository.Save();
        }

        public void Dispose()
        {
            characterRepository.Dispose();
        }

        public IEnumerable<Character> GetCharacters()
        {
            return characterRepository.FindAllCharacters().ToList();
        }

        public void RemoveCharacter(Character character)
        {
            characterRepository.DeleteCharacter(character.CharacterId);
            characterRepository.Save();
        }

        public void UpdateCharacter(Character character)
        {
            characterRepository.UpdateCharacter(character);
            characterRepository.Save();
        }
    }
}
