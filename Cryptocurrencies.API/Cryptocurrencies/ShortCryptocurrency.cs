using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.API.Cryptocurrencies
{
    public class ShortCryptocurrency
    {
        public int Rank { get; init; }
        public string Symbol { get; init; }
        public decimal Supply { get; init; }
        public decimal PriceUsd { get; init; }
        public decimal MarketCapUsd { get; init; }
        public decimal VolumeUsd24Hr { get; init; }
        public decimal VWAP24Hr { get; init; }
        public decimal ChangePercent24Hr { get; init; }
    }
}
