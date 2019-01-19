using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using DTO.Entities;
using Service.Implementations;
using Designer.ViewModels.Commands;

namespace Designer.ViewModels
{
    public class ItemWindowViewModel : INotifyPropertyChanged
    {
        private Item _item;
        private ICollection<Item> _itemList;
        private readonly ItemWindowCommand _itemWindowCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemWindowButtonClick => _itemWindowCommand;

        #region Properties

        public ICollection<Item> ItemCollectionList
        {
            get => _itemList;
            set
            {
                _itemList = value;
                OnPropertyChanged("ItemCollectionList");
            }
        }

        public string ItemNameText
        {
            get => _item.Name;
            set
            {
                _item.Name = value; 
                OnPropertyChanged("ItemNameText");
            }
        }

        public Item SelectedItem
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        #endregion

        public ItemWindowViewModel()
        {
            _itemWindowCommand = new ItemWindowCommand(this);
            var itemService = new ItemService();
            ItemCollectionList = itemService.GetItems().ToList();
        }

        public void CreateItem()
        {
            var itemService = new ItemService();
            var roomService = new RoomService();

            if (!roomService.GetRooms().Any())
            {
                return;
            }

            _item = new Item
            {
                Name = "Item #" + (itemService.GetItems().Count() + 1),
                InteractableObjectRoom = roomService.GetRooms().ElementAt(0),
                InteractableObjectRoomId = roomService.GetRooms().ElementAt(0).RoomId
            };
            itemService.AddItem(_item);
            ItemCollectionList = itemService.GetItems().ToList();
            itemService.Dispose();
        }

        public void SaveItem()
        {
            var itemService = new ItemService();
            itemService.UpdateItem(_item);
            ItemCollectionList = itemService.GetItems().ToList();
            itemService.Dispose();
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
