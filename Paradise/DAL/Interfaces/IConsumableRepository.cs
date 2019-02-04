using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IConsumableRepository : IDisposable
    {
        IEnumerable<Consumable> FindAllConsumables();
        Consumable GetConsumableById(int consumableId);
        void InsertConsumable(Consumable consumable);
        void DeleteConsumable(int consumableId);
        void UpdateConsumable(Consumable consumable);
        void Save();
    }
}