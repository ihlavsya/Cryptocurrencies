using AutoMapper;
using Cryptocurrencies.API.Cryptocurrencies;
using Cryptocurrencies.Pages;
using Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private readonly IMapper _mapper;
        public MainWindow(ICryptocurrenciesService cryptocurrenciesService, IMapper mapper)
        {
            _cryptocurrenciesService = cryptocurrenciesService;
            _mapper = mapper;
            InitializeComponent();
            Main.Content = new MainPage();
            LoadData();
        }

        private async Task LoadData()
        {
            var cryptocurrencies = await _cryptocurrenciesService.GetTopNCryptocurrencies(10);
            CryptocurrenciesViewModel cryptocurrenciesViewModel = new CryptocurrenciesViewModel();
            cryptocurrenciesViewModel.RowCryptocurrencyInfoViewModels = _mapper.Map<ObservableCollection<RowCryptocurrencyInfoViewModel>>(cryptocurrencies);
            DataContext = cryptocurrenciesViewModel;
        }
    }
}
    