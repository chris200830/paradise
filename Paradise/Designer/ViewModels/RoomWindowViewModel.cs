using DTO.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Service.Implementations;
using Designer.ViewModels.Commands;

namespace Designer.ViewModels
{
    public class RoomWindowViewModel : INotifyPropertyChanged
    {
        private Room _room;
        private ICollection<Room> _roomList;

        private readonly RoomWindowCommand _roomWindowCommand;
        public ICommand RoomWindowButtonClick => _roomWindowCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        public ICollection<InteractableObject> RoomItemsCollectionList
        {
            get => _room.RoomInteractableObjects;
            set => _room.RoomInteractableObjects = value;
        }

        public ICollection<Room> RoomCollectionList
        {
            get => _roomList;
            set
            {
                _roomList = value;
                OnPropertyChanged("RoomCollectionList");
            }
        }

        public Room SelectedRoom
        {
            get => _room;
            set
            {
                _room = value; 
                OnPropertyChanged("SelectedRoom");
            }
        }

        public Room ViewModelRoomUp
        {
            get => _room.RoomUp;
            set => _room.RoomUp = value;
        }

        public Room ViewModelRoomRight
        {
            get => _room.RoomRight;
            set => _room.RoomRight = value;
        }

        public Room ViewModelRoomDown
        {
            get => _room.RoomDown;
            set => _room.RoomDown = value;
        }

        public Room ViewModelRoomLeft
        {
            get => _room.RoomLeft;
            set => _room.RoomLeft = value;
        }

        public string TxtRoomName
        {
            get => _room.Name;
            set => _room.Name = value;
        }

        #endregion

        public RoomWindowViewModel()
        {
            _room = new Room() {RoomInteractableObjects = new List<InteractableObject>()};

            _roomWindowCommand = new RoomWindowCommand(this);
            var roomService = new RoomService();
            RoomCollectionList = roomService.GetRooms().ToList();
        }

        public void CreateNewRoom()
        {
            var roomService = new RoomService();
            _room = new Room {Name = "Room #" + (roomService.GetRooms().Count() + 1), };
            roomService.AddRoom(_room);
            RoomCollectionList = roomService.GetRooms().ToList();
            roomService.Dispose();
        }

        public void SaveRoom()
        {
            var roomService = new RoomService();
            roomService.UpdateRoom(_room);
            RoomCollectionList = roomService.GetRooms().ToList();
            roomService.Dispose();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
