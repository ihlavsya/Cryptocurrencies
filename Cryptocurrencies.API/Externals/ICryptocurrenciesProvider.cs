using Cryptocurrencies.API.Cryptocurrencies;
using Cryptocurrencies.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.API.Externals
{
    public interface ICryptocurrenciesProvider
    {
        Task<IEnumerable<ShortCryptocurrencyDTO>> GetTopNCryptocurrencies(int top);
    }
}
