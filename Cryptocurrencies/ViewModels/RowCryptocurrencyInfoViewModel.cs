using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ViewModels
{
    public class RowCryptocurrencyInfoViewModel : ViewModelBase
    {
        public int Rank { get; init; }
        public string Symbol { get; init; }
        public decimal Supply { get; init; }
        public decimal PriceUsd { get; init; }
        public decimal MarketCapUsd { get; init; }
        public decimal VolumeUsd24Hr { get; init; }
        public decimal VWAP24Hr { get; init; }
        public decimal ChangePercent24Hr { get; init; }

        public RowCryptocurrencyInfoViewModel(int rank, string symbol, decimal supply, decimal priceUsd, decimal marketCapUsd, decimal volumeUsd24Hr, decimal vWAP24Hr, decimal changePercent24Hr)
        {
            Rank = rank;
            Symbol = symbol;
            Supply = supply;
            PriceUsd = priceUsd;
            MarketCapUsd = marketCapUsd;
            VolumeUsd24Hr = volumeUsd24Hr;
            VWAP24Hr = vWAP24Hr;
            ChangePercent24Hr = changePercent24Hr;
        }
    }
}
