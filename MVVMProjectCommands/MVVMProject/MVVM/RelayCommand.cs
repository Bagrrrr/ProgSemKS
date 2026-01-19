using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMProject.MVVM
{
    // RelayCommand je třída, která implementuje ICommand.
    // ICommand je rozhraní, které WPF používá pro příkazy (např. tlačítka).
    // Hlavní myšlenka: "tlačítko nevolá přímo metodu, ale volá příkaz".
    internal class RelayCommand : ICommand
    {
        // _execute uchovává metodu, která se má spustit, když příkaz provedeme (např. klikneme na tlačítko)
        private Action<object> _execute;

        // _canExecute uchovává metodu, která rozhoduje, jestli je příkaz povolen
        // Pokud vrátí false, tlačítko je zneaktivněné (disabled)
        private Func<object, bool> _canExecute;

        // Konstruktor, který přijímá metody, které příkaz provádí
        // execute = co se má spustit
        // canExecute = volitelná metoda, která určuje, jestli příkaz jde provést
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Událost, kterou ICommand vyžaduje.
        // WPF ji používá, aby věděl, kdy se má překreslit tlačítko (enabled/disabled)
        public event EventHandler? CanExecuteChanged
        {
            // Přihlásíme se na CommandManager.RequerySuggested,
            // což je mechanismus WPF, který periodicky kontroluje, jestli se tlačítka mají povolit/zakázat
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Určuje, jestli příkaz může běžet
        public bool CanExecute(object? parameter)
        {
            // Pokud není _canExecute nastaveno, příkaz je povolen
            // Jinak zavoláme funkci _canExecute s parametrem
            return _canExecute == null || _canExecute(parameter);
        }

        // Tady se vykoná skutečná logika příkazu
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
