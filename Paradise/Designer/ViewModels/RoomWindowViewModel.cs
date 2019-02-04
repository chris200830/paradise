using DTO.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Designer.ViewModels.Commands;
using DTO.Entities.Enums;
using Service.Interfaces;
using Unity;

namespace Designer.ViewModels
{
    public class RoomWindowViewModel : INotifyPropertyChanged
    {
        private readonly IRepositoryService repositoryService = Initializer.UnityContainer.Resolve<IRepositoryService>();
        private ICollection<Room> _roomList;
        public ICommand RoomWindowButtonClick => _roomWindowCommand;

        private Room _room;
        private readonly RoomWindowCommand _roomWindowCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        public ICollection<InteractiveObject> RoomInteractiveObjectsCollectionList { get; set; }

        public InteractiveObject ComboBoxInteractiveObject { get; set; }

        public InteractiveObject SelectedInteractiveObject { get; set; }

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
            set
            {
                _room.RoomUp = value;
                _room.RoomUpId = value.Id;
            }
        }

        public Room ViewModelRoomRight
        {
            get => _room.RoomRight;
            set
            {
                _room.RoomRight = value;
                _room.RoomRightId = value.Id;
            }
        }

        public Room ViewModelRoomDown
        {
            get => _room.RoomDown;
            set
            {
                _room.RoomDown = value;
                _room.RoomDownId = value.Id;
            }
        }

        public Room ViewModelRoomLeft
        {
            get => _room.RoomLeft;
            set
            {
                _room.RoomLeft = value;
                _room.RoomLeftId = value.Id;
            }
        }

        public string TxtRoomName
        {
            get => _room.RoomName;
            set
            {
                _room.RoomName = value;
            }
        }

        public Location RoomLocation
        {
            get => _room.Location;
            set => _room.Location = value;
        }

        #endregion

        public RoomWindowViewModel()
        {
            _room = new Room() {RoomInteractiveObjects = new List<InteractiveObject>()};
            _roomWindowCommand = new RoomWindowCommand(this);
            RoomCollectionList = repositoryService.FindAllRooms().ToList();
            RoomInteractiveObjectsCollectionList = repositoryService.FindAllInteractiveObjects().ToList();
        }

        public void CreateNewRoom()
        {
            _room = new Room
            {
                RoomName = "Room #" + (repositoryService.FindAllRooms().Count() + 1),
                RoomUpId = 69,
                RoomDownId = 69,
                RoomLeftId = 69,
                RoomRightId = 69,
                RoomInteractiveObjects = new List<InteractiveObject>()
        };
            repositoryService.AddRoom(_room);
            repositoryService.Commit();
            RoomCollectionList = repositoryService.FindAllRooms().ToList();
        }

        public void SaveRoom()
        {
            repositoryService.UpdateRoom(_room);
            repositoryService.Commit();
            RoomCollectionList = repositoryService.FindAllRooms().ToList();
        }

        public void AddObjectToRoom()
        {
            if (ComboBoxInteractiveObject == null)
            {
                return;
            }

            if (_room.RoomInteractiveObjects == null)
            {
                _room.RoomInteractiveObjects = new List<InteractiveObject>();
            }

            _room.RoomInteractiveObjects.Add(ComboBoxInteractiveObject);
            repositoryService.UpdateRoom(_room);
            repositoryService.Commit();
        }

        public void RemoveObjectFromRoom()
        {
            if (_room.RoomInteractiveObjects == null)
            {
                return;
            }

            _room.RoomInteractiveObjects.Remove(SelectedInteractiveObject);
            SelectedInteractiveObject.InteractiveObjectRoom = repositoryService.FindRoom(69);
            repositoryService.UpdateRoom(_room);
            repositoryService.UpdateInteractiveObject(SelectedInteractiveObject);
            repositoryService.Commit();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
