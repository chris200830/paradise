using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using DTO.Entities;
using Designer.ViewModels.Commands;
using Service.Interfaces;
using Unity;

namespace Designer.ViewModels
{
    public class InteractiveObjectWindowViewModel : INotifyPropertyChanged
    {
        private readonly IRepositoryService repositoryService = Initializer.UnityContainer.Resolve<IRepositoryService>();
        private InteractiveObject interactiveObject;
        private ICollection<InteractiveObject> interactiveObjectList;
        private readonly InteractiveObjectWindowCommand interactiveObjectWindowCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand InteractiveObjectWindowButtonClick => interactiveObjectWindowCommand;

        #region Properties

        public ICollection<InteractiveObject> InteractiveObjectsCollectionList
        {
            get => interactiveObjectList;
            set
            {
                interactiveObjectList = value;
                OnPropertyChanged("InteractiveObjectsCollectionList");
            }
        }

        public InteractiveObject SelectedInteractiveObject
        {
            get => interactiveObject;
            set
            {
                interactiveObject = value;
                OnPropertyChanged("SelectedInteractiveObject");
            }
        }

        #endregion

        public InteractiveObjectWindowViewModel()
        {
            interactiveObject = new InteractiveObject();
            interactiveObjectWindowCommand = new InteractiveObjectWindowCommand(this);
            InteractiveObjectsCollectionList = repositoryService.FindAllInteractiveObjects().ToList();
        }

        public void CreateObject()
        {
            interactiveObject = new InteractiveObject()
            {
                Name = "Object #" + (repositoryService.FindAllInteractiveObjects().Count() + 1),
                Interactions = new List<Interaction>(),
                InteractiveObjectRoom = repositoryService.FindRoom(69)
            };

            repositoryService.AddInteractiveObject(interactiveObject);
            repositoryService.Commit();
            InteractiveObjectsCollectionList = repositoryService.FindAllInteractiveObjects();
        }

        public void SaveObject()
        {
            repositoryService.UpdateInteractiveObject(interactiveObject);
            repositoryService.Commit();
            InteractiveObjectsCollectionList = repositoryService.FindAllInteractiveObjects();
        }

        public void CreateItem()
        {
            //var itemService = new ItemService();
            //var roomService = new RoomService();

            //if (!roomService.GetRooms().Any())
            //{
            //    return;
            //}

            //_item = new Item
            //{
            //    Name = "Item #" + (itemService.GetItems().Count() + 1),
            //    InteractiveObjectRoom = roomService.GetRooms().ElementAt(0),
            //    InteractiveObjectId = roomService.GetRooms().ElementAt(0).Id
            //};
            //itemService.AddItem(_item);
            //ItemCollectionList = itemService.GetItems().ToList();
            //itemService.Dispose();
        }

        public void SaveItem()
        {
            //var itemService = new ItemService();
            //itemService.UpdateItem(_item);
            //ItemCollectionList = itemService.GetItems().ToList();
            //itemService.Dispose();
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
