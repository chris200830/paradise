using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface IItemService
    {
        void AddItem(Item item);
        void UpdateItem(Item item);
        void RemoveItem(Item item);
        void Dispose();
        IEnumerable<Item> GetItems();
    }
}