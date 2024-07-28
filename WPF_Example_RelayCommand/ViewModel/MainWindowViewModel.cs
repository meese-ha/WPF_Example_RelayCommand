using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Example_RelayCommand.MVVM;
using WPF_Example_RelayCommand.Model;

namespace WPF_Example_RelayCommand.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem(), canexecute => { return true; });
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canexecute => selectedItem != null);
        public RelayCommand SvaeCommand => new RelayCommand(execute => save(), canexecute => CanSave());

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();

        }


        private Item selectedItem;

        public Item SelectedItem
        {

            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnProPertyChanged();
            }

        }

        private void AddItem()
        {
            Items.Add(new Item 
            {
                Name = "NEW ITEM",
                SerialNumber="XXXXX",
                Quantity = 0
            
            });
        }

        private void DeleteItem()
        { Items.Remove(selectedItem); }

        private void save()
        {
            //save

        }

        private bool CanSave()
        {
            return true;
        }


    }
}
