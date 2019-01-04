using System;
using System.Windows.Input;

namespace Designer.ViewModels.Commands
{
    public class ItemWindowCommand : ICommand
    {
        private readonly ItemWindowViewModel _itemWindowViewModel;
        public event EventHandler CanExecuteChanged;

        public ItemWindowCommand(ItemWindowViewModel itemWindowViewModel)
        {
            _itemWindowViewModel = itemWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var type = (string) parameter;

            switch (type)
            {
                case "Create":
                    _itemWindowViewModel.CreateItem();
                    break;
                case "Save":
                    _itemWindowViewModel.SaveItem();
                    break;
                default:
                    break;
            }
        }
    }
}
