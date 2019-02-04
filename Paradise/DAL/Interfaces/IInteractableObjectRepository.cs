using System;
using System.Collections.Generic;
using DAL.Database;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IInteractiveObjectRepository : IDisposable
    {
        IEnumerable<InteractiveObject> FindAllInteractiveObjects();
        InteractiveObject GetInteractiveObjectById(int interactiveObjectId);
        void InsertInteractiveObject(InteractiveObject interactiveObject);
        void DeleteInteractiveObject(int interactiveObjectId);
        void UpdateInteractiveObject(InteractiveObject interactiveObject);
        void Save();
    }
}