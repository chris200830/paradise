using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface IRepositoryService
    {
        void AddRoom(Room room);
        void AddCharacter(Character character);
        void AddConsumable(Consumable consumable);
        void AddInteraction(Interaction interaction);
        void AddInteractiveObject(InteractiveObject interactiveObject);
        void AddDialogue(Dialogue dialogue);

        void DeleteRoom(Room room);
        void DeleteCharacter(Character character);
        void DeleteConsumable(Consumable consumable);
        void DeleteInteraction(Interaction interaction);
        void DeleteInteractiveObject(InteractiveObject interactiveObject);
        void DeleteDialogue(Dialogue dialogue);

        void UpdateRoom(Room room);
        void UpdateCharacter(Character character);
        void UpdateConsumable(Consumable consumable);
        void UpdateInteraction(Interaction interaction);
        void UpdateInteractiveObject(InteractiveObject interactiveObject);
        void UpdateDialogue(Dialogue dialogue);

        Room FindRoom(int roomId);
        Character FindCharacter(int characterId);
        Consumable FindConsumable(int consumableId);
        Interaction FindInteraction(int interactionId);
        InteractiveObject FindInteractiveObject(int interactiveObjectId);
        Dialogue FindDialogue(int dialogueId);

        List<Room> FindAllRooms();
        List<Character> FindAllCharacters();
        List<Consumable> FindAllConsumables();
        List<Interaction> FindAllInteractions();
        List<InteractiveObject> FindAllInteractiveObjects();
        List<Dialogue> FindAllDialogues();

        void Commit();
    }
}