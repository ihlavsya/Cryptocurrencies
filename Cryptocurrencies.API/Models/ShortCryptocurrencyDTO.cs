using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.API.Models
{
    public class ShortCryptocurrencyDTO
    {
        [JsonProperty("rank")]
        public int Rank { get; init; }

        [JsonProperty("symbol")]
        public string Symbol { get; init; }
        [JsonProperty("supply")]
        public decimal Supply { get; init; }
        [JsonProperty("priceUsd")]
        public decimal PriceUsd { get; init; }

        [JsonProperty("marketCapUsd")]
        public decimal MarketCapUsd { get; init; }
        [JsonProperty("volumeUsd24Hr")]
        public decimal VolumeUsd24Hr { get; init; }
        [JsonProperty("vwap24Hr")]
        public decimal VWAP24Hr { get; init; }
        [JsonProperty("changePercent24Hr")]
        public decimal ChangePercent24Hr { get; init; }
    }
}
