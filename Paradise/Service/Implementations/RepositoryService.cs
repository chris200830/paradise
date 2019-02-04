using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    internal class RepositoryService : IRepositoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public RepositoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddRoom(Room room)
        {
            unitOfWork.RoomRepository.InsertEntity(room);
        }

        public void AddCharacter(Character character)
        {
            unitOfWork.CharacterRepository.InsertEntity(character);
        }

        public void AddConsumable(Consumable consumable)
        {
            unitOfWork.ConsumableRepository.InsertEntity(consumable);
        }

        public void AddInteraction(Interaction interaction)
        {
            unitOfWork.InteractionRepository.InsertEntity(interaction);
        }

        public void AddInteractiveObject(InteractiveObject interactiveObject)
        {
            unitOfWork.InteractiveObjectRepository.InsertEntity(interactiveObject);
        }

        public void AddDialogue(Dialogue dialogue)
        {
            unitOfWork.DialogueRepository.InsertEntity(dialogue);
        }

        public void DeleteRoom(Room room)
        {
            unitOfWork.RoomRepository.DeleteEntity(room);
        }

        public void DeleteCharacter(Character character)
        {
            unitOfWork.CharacterRepository.DeleteEntity(character);
        }

        public void DeleteConsumable(Consumable consumable)
        {
            unitOfWork.ConsumableRepository.DeleteEntity(consumable);
        }

        public void DeleteInteraction(Interaction interaction)
        {
            unitOfWork.InteractionRepository.DeleteEntity(interaction);
        }

        public void DeleteInteractiveObject(InteractiveObject interactiveObject)
        {
            unitOfWork.InteractiveObjectRepository.DeleteEntity(interactiveObject);
        }
         
        public void DeleteDialogue(Dialogue dialogue)
        {
            unitOfWork.DialogueRepository.DeleteEntity(dialogue);
        }

        public void UpdateRoom(Room room)
        {
            unitOfWork.RoomRepository.UpdateEntity(room);
        }

        public void UpdateCharacter(Character character)
        {
            unitOfWork.CharacterRepository.UpdateEntity(character);
        }

        public void UpdateConsumable(Consumable consumable)
        {
            unitOfWork.ConsumableRepository.UpdateEntity(consumable);
        }

        public void UpdateInteraction(Interaction interaction)
        {
            unitOfWork.InteractionRepository.UpdateEntity(interaction);
        }

        public void UpdateInteractiveObject(InteractiveObject interactiveObject)
        {
            unitOfWork.InteractiveObjectRepository.UpdateEntity(interactiveObject);
        }

        public void UpdateDialogue(Dialogue dialogue)
        {
            unitOfWork.DialogueRepository.UpdateEntity(dialogue);
        }

        public Room FindRoom(int roomId)
        {
            return unitOfWork.RoomRepository.GetEntityById(roomId);
        }

        public Character FindCharacter(int characterId)
        {
            return unitOfWork.CharacterRepository.GetEntityById(characterId);
        }

        public Consumable FindConsumable(int consumableId)
        {
            return unitOfWork.ConsumableRepository.GetEntityById(consumableId);
        }

        public Interaction FindInteraction(int interactionId)
        {
            return unitOfWork.InteractionRepository.GetEntityById(interactionId);
        }

        public InteractiveObject FindInteractiveObject(int interactiveObjectId)
        {
            return unitOfWork.InteractiveObjectRepository.GetEntityById(interactiveObjectId);
        }

        public Dialogue FindDialogue(int dialogueId)
        {
            return unitOfWork.DialogueRepository.GetEntityById(dialogueId);
        }

        public List<Room> FindAllRooms()
        {
            return unitOfWork.RoomRepository.FindAllEntities().ToList();
;        }

        public List<Character> FindAllCharacters()
        {
            return unitOfWork.CharacterRepository.FindAllEntities().ToList();
        }

        public List<Consumable> FindAllConsumables()
        {
            return unitOfWork.ConsumableRepository.FindAllEntities().ToList();
        }

        public List<Interaction> FindAllInteractions()
        {
            return unitOfWork.InteractionRepository.FindAllEntities().ToList();
        }

        public List<InteractiveObject> FindAllInteractiveObjects()
        {
            return unitOfWork.InteractiveObjectRepository.FindAllEntities().ToList();
        }

        public List<Dialogue> FindAllDialogues()
        {
            return unitOfWork.DialogueRepository.FindAllEntities().ToList();
        }

        public void Commit()
        {
            unitOfWork.SaveChanges();
        }
    }
}
