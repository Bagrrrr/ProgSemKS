using MVVMProject.Model;
using MVVMProject.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProject.ViewModel
{
    
    internal class MainWindowViewModel : ViewModelBase
    {
        // Tento řádek vytváří příkaz pro tlačítko „Přidat“
        // RelayCommand říká: "když někdo klikne, zavolej tuto metodu"
        // execute => AddItem() znamená: ignorujeme parametr (exekuce), jen zavoláme metodu AddItem()
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());

        // Tento řádek vytváří příkaz pro tlačítko „Smazat“
        // Tlačítko se spustí jen tehdy, pokud je vybraná nějaká položka (SelectedItem != null)
        // execute => DeleteItem() říká, co se má stát po kliknutí
        // canExecute => SelectedItem != null říká, zda je tlačítko aktivní
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);

        // '=>' je jen zkrácený zápis pro malou funkci / metodu, kterou předáváme jako parametr.


        public ObservableCollection<Item> Items { get; set; }
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
            
            
        }

        private Item selectedItem;


        public Item SelectedItem
        {
            get { return selectedItem; }
            set { 
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private void AddItem()
        {
            Items.Add(new Item()
            {
                Name = "Napis ukol",
                Date = DateTime.Now
                

            });
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }


    }
}
