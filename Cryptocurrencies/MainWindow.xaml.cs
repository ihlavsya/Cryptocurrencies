using AutoMapper;
using Cryptocurrencies.API.Cryptocurrencies;
using Cryptocurrencies.API.Exceptions;
using Cryptocurrencies.Pages;
using Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

        private void txtSearchBox_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void languageBtn_Click(object sender, RoutedEventArgs e)
        {
            var neutralCulture = Thread.CurrentThread.CurrentCulture.Parent.Name;
            if (neutralCulture.Equals("en", StringComparison.OrdinalIgnoreCase))
            {
                App.ChangeCulture("uk-UA");
            }
            else
            {
                App.ChangeCulture("en");
            }
        }

        private void themeBtn_Click(object sender, RoutedEventArgs e)
        {
            var darkUri = new Uri("Themes/dark.xaml", UriKind.Relative);
            var lightUri = new Uri("Themes/light.xaml", UriKind.Relative);
            var currentTheme = App.Current?.Resources?.MergedDictionaries?.LastOrDefault()?.Source;
            if (currentTheme?.ToString() == darkUri.ToString())
            {
                AppTheme.ChangeTheme(lightUri);
            }
            else
            {
                AppTheme.ChangeTheme(darkUri);
            }
        }

        private async void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            var textbox = txtSearchBox;
            if (textbox != null)
            {
                string searchstr = textbox.Text;
                if (!string.IsNullOrEmpty(searchstr))
                {
                    CryptocurrenciesViewModel cryptocurrenciesViewModel = new CryptocurrenciesViewModel();
                    try
                    {
                        var data = await _cryptocurrenciesService.GetCryptocurrencyById(searchstr);
                        var dataList = new ObservableCollection<RowCryptocurrencyInfoViewModel>();
                        var row = _mapper.Map<RowCryptocurrencyInfoViewModel>(data);
                        dataList.Add(row);
                        cryptocurrenciesViewModel.RowCryptocurrencyInfoViewModels = dataList;
                    }
                    catch (DataNotFoundException)
                    {
                    }
                    finally
                    {
                        DataContext = cryptocurrenciesViewModel;
                    }
                }
            }
        }
    }
}
