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
using Haley.Utils;

namespace Cryptocurrencies
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IMapper _mapper;
        HttpCryptocurrenciesProvider _httpCryptocurrenciesProvider;
        public App()
        {
            LangUtils.Register();
            ChangeCulture("uk-UA");
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShortCryptocurrencyDTO, ShortCryptocurrency>();
                cfg.CreateMap<ShortCryptocurrency, RowCryptocurrencyInfoViewModel>();
            });
            _mapper = new Mapper(config);
            _httpCryptocurrenciesProvider = new HttpCryptocurrenciesProvider();
        }

        public static void ChangeCulture(string code)
        {
            LangUtils.ChangeCulture(code);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            ICryptocurrenciesService cryptocurrenciesService = new CryptocurrenciesService(_httpCryptocurrenciesProvider, _mapper);
            MainWindow = new MainWindow(cryptocurrenciesService, _mapper);
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
