using Cryptocurrencies.API.Cryptocurrencies;
using Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptocurrencies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICryptocurrenciesService _cryptocurrenciesService;
        public MainWindow(ICryptocurrenciesService cryptocurrenciesService)
        {
            _cryptocurrenciesService = cryptocurrenciesService;
            InitializeComponent();
            LoadData();
        }

        private async Task LoadData()
        {
            var cryptocurrencies = await _cryptocurrenciesService.GetTopNCryptocurrencies(10);
            CryptocurrenciesViewModel cryptocurrenciesViewModel = new CryptocurrenciesViewModel();
            // here should be mapping between RowCryptocurrencyInfoViewModel
            var a = cryptocurrencies.First();
            cryptocurrenciesViewModel.RowCryptocurrencyInfoViewModels.Add(new RowCryptocurrencyInfoViewModel(a.Rank, a.Symbol, a.Supply, a.PriceUsd, a.MarketCapUsd, a.VolumeUsd24Hr, a.VWAP24Hr, a.ChangePercent24Hr));
            DataContext = cryptocurrenciesViewModel;
        }
    }
}
    