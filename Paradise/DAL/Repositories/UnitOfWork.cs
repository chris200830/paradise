using System;
using DAL.Database;
using DAL.Interfaces;
using DTO.Entities;

namespace DAL.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly WpfAppContext context = new WpfAppContext();

        #region Repositories

        private IRepository<Room> roomRepository;
        private IRepository<Character> characterRepository;
        private IRepository<InteractiveObject> interactiveObjectRepository;
        private IRepository<Consumable> consumableRepository;
        private IRepository<Dialogue> dialogueRepository;
        private IRepository<Interaction> interactionRepository;
        private IRepository<MainCharacter> mainCharacterRepository;

        public IRepository<Room> RoomRepository
        {
            get
            {
                if (this.roomRepository == null)
                {
                    this.roomRepository = new Repository<Room>(context);
                }

                return roomRepository;
            }
        }

        public IRepository<Character> CharacterRepository
        {
            get
            {
                if (this.characterRepository == null)
                {
                    this.characterRepository = new Repository<Character>(context);
                }

                return characterRepository;
            }
        }

        public IRepository<InteractiveObject> InteractiveObjectRepository
        {
            get
            {
                if (this.interactiveObjectRepository == null)
                {
                    this.interactiveObjectRepository = new Repository<InteractiveObject>(context);
                }

                return interactiveObjectRepository;
            }
        }

        public IRepository<Consumable> ConsumableRepository
        {
            get
            {
                if (this.consumableRepository == null)
                {
                    this.consumableRepository = new Repository<Consumable>(context);
                }

                return consumableRepository;
            }
        }

        public IRepository<Dialogue> DialogueRepository
        {
            get
            {
                if (this.dialogueRepository == null)
                {
                    this.dialogueRepository = new Repository<Dialogue>(context);
                }

                return dialogueRepository;
            }
        }

        public IRepository<Interaction> InteractionRepository
        {
            get
            {
                if (this.interactionRepository == null)
                {
                    this.interactionRepository = new Repository<Interaction>(context);
                }

                return interactionRepository;
            }
        }

        public IRepository<MainCharacter> MainCharacterRepository
        {
            get
            {
                if (this.mainCharacterRepository == null)
                {
                    this.mainCharacterRepository = new Repository<MainCharacter>(context);
                }

                return mainCharacterRepository;
            }
        }

        #endregion

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
