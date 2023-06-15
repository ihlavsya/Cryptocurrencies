using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.API.Cryptocurrencies
{
    public interface ICryptocurrenciesService
    {
        Task<IEnumerable<ShortCryptocurrency>> GetTopNCryptocurrencies(int top);
    }
}
