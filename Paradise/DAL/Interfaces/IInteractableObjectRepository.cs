using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IInteractableObjectRepository : IDisposable
    {
        IEnumerable<InteractableObject> FindAllInteractableObjects();
        InteractableObject GetInteractableObjectById(int interactableObjectId);
        void InsertInteractableObject(InteractableObject interactableObject);
        void DeleteInteractableObject(int interactableObjectId);
        void UpdateInteractableObject(InteractableObject interactableObject);
        void Save();
    }
}