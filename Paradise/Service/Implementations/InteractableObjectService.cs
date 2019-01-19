using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    public class InteractableObjectService : IInteractableObjectService
    {
        private readonly IInteractableObjectRepository interactableObjectRepository;

        public InteractableObjectService()
        {
            var context = new WpfAppContext();
            interactableObjectRepository = new InteractableObjectRepository(context);
        }

        public void AddInteractableObject(InteractableObject interactableObject)
        {
            interactableObjectRepository.InsertInteractableObject(interactableObject);
            interactableObjectRepository.Save();
        }

        public void UpdateInteractableObject(InteractableObject interactableObject)
        {
            interactableObjectRepository.UpdateInteractableObject(interactableObject);
            interactableObjectRepository.Save();
        }

        public void RemoveInteractableObject(InteractableObject interactableObject)
        {
            interactableObjectRepository.DeleteInteractableObject(interactableObject.InteractableObjectId);
            interactableObjectRepository.Save();
        }

        public void Dispose()
        {
            interactableObjectRepository.Dispose();
        }

        public IEnumerable<InteractableObject> GetInteractableObjects()
        {
            return interactableObjectRepository.FindAllInteractableObjects().ToList();
        }
    }
}
