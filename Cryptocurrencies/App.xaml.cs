using AutoMapper;
using Cryptocurrencies.API.Cryptocurrencies;
using Cryptocurrencies.API.Externals;
using Cryptocurrencies.API.Models;
using Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Cryptocurrencies
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IMapper _mapper;
        public App()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShortCryptocurrencyDTO, ShortCryptocurrency> ());
            _mapper = new Mapper(config);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            HttpCryptocurrenciesProvider httpCryptocurrenciesProvider = new HttpCryptocurrenciesProvider();
            ICryptocurrenciesService cryptocurrenciesService = new CryptocurrenciesService(httpCryptocurrenciesProvider, _mapper);
            MainWindow = new MainWindow(cryptocurrenciesService);
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
