using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ViewModels
{
    internal class CryptocurrenciesViewModel:ViewModelBase
    {
        public ObservableCollection<RowCryptocurrencyInfoViewModel> RowCryptocurrencyInfoViewModels { get; set; }

        public CryptocurrenciesViewModel()
        {
            RowCryptocurrencyInfoViewModels = new ObservableCollection<RowCryptocurrencyInfoViewModel> ();
            RowCryptocurrencyInfoViewModels.Add(new RowCryptocurrencyInfoViewModel(1, "test", 2, 3, 4, 5, 6, 7));
            RowCryptocurrencyInfoViewModels.Add(new RowCryptocurrencyInfoViewModel(2, "test2", 20, 30, 40, 50, 60, 70));
            RowCryptocurrencyInfoViewModels.Add(new RowCryptocurrencyInfoViewModel(3, "test3", 21, 31, 41, 51, 61, 71));
        }
    }
}
