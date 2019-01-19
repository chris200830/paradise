using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface IInteractableObjectService
    {
        void AddInteractableObject(InteractableObject interactableObject);
        void UpdateInteractableObject(InteractableObject interactableObject);
        void RemoveInteractableObject(InteractableObject interactableObject);
        void Dispose();
        IEnumerable<InteractableObject> GetInteractableObjects();
    }
}