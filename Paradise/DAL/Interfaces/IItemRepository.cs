using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IItemRepository : IDisposable
    {
        IEnumerable<Item> FindAllItems();
        Item GetItemById(int itemId);
        void InsertItem(Item item);
        void DeleteItem(int itemId);
        void UpdateItem(Item item);
        void Save();
    }
}