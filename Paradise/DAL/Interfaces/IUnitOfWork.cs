using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Room> RoomRepository { get; }
        IRepository<Character> CharacterRepository { get; }
        IRepository<InteractiveObject> InteractiveObjectRepository { get; }
        IRepository<Consumable> ConsumableRepository { get; }
        IRepository<Dialogue> DialogueRepository { get; }
        IRepository<Interaction> InteractionRepository { get; }
        IRepository<MainCharacter> MainCharacterRepository { get; }

        void SaveChanges();
    }
}