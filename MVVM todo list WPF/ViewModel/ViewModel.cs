using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MVVM_todo_list_WPF.Model;

namespace MVVM_todo_list_WPF.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());

        // Tento řádek vytváří příkaz pro tlačítko „Smazat“
        // Tlačítko se spustí jen tehdy, pokud je vybraná nějaká položka (SelectedItem != null)
        // execute => DeleteItem() říká, co se má stát po kliknutí
        // canExecute => SelectedItem != null říká, zda je tlačítko aktivní
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
        // ObservableCollection<Item> je speciální kolekce (seznam), která informuje WPF, 
        // když se v ní něco změní – například když přidáme nebo odstraníme položku.
        // Díky tomu se všechny UI prvky, které jsou na Items navázané (např. DataGrid, ListBox),
        // automaticky aktualizují, aniž bychom museli něco volat ručně.
        public ObservableCollection<Item> Items { get; set; }
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();

            Items.Add(new Item()
            {
                Name = "Product1",
                SerialNumber = "0001",
                Quantity = 5
            });
            Items.Add(new Item()
            {
                Name = "Product2",
                SerialNumber = "0002",
                Quantity = 3
            });
        }

        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        private void AddItem()
        {
            Items.Add(new Item()
            {
                Name = "ProductX",
                SerialNumber = "000X",
                Quantity = 0
            });
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }

    }
}
