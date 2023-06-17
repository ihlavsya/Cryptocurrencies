using AutoMapper;
using Cryptocurrencies.API.Externals;
using Cryptocurrencies.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cryptocurrencies.API.Cryptocurrencies
{
    public class CryptocurrenciesService : ICryptocurrenciesService
    {
        private readonly ICryptocurrenciesProvider _cryptocurrenciesProvider;
        private readonly IMapper _mapper;

        public CryptocurrenciesService(ICryptocurrenciesProvider cryptocurrenciesProvider, IMapper mapper)
        {
            _cryptocurrenciesProvider = cryptocurrenciesProvider;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ShortCryptocurrency>> GetTopNCryptocurrencies(int top)
        {
            var cryptocurrenciesDTO = await _cryptocurrenciesProvider.GetTopNCryptocurrencies(top);
            var cryptocurrencies = _mapper.Map<IEnumerable<ShortCryptocurrency>>(cryptocurrenciesDTO);
            return cryptocurrencies;
        }

        public async Task<ShortCryptocurrency> GetCryptocurrencyById(string id)
        {
            var cryptocurrencyDTO = await _cryptocurrenciesProvider.GetCryptocurrencyById(id);  
            var cryptocurrency = _mapper.Map<ShortCryptocurrency>(cryptocurrencyDTO);
            return cryptocurrency;
        }
    }
}
