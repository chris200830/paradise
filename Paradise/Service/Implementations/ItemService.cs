using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;

        public ItemService()
        {
            var context = new WpfAppContext();
            itemRepository = new ItemRepository(context);
        }

        public void AddItem(Item item)
        {
            itemRepository.InsertItem(item);
            itemRepository.Save();
        }

        public void Dispose()
        {
            itemRepository.Dispose();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemRepository.FindAllItems();
        }

        public void RemoveItem(Item item)
        {
            itemRepository.DeleteItem(item.ItemId);
            itemRepository.Save();
        }

        public void UpdateItem(Item item)
        {
            itemRepository.UpdateItem(item);
            itemRepository.Save();
        }
    }
}
