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
        }
    }
}
