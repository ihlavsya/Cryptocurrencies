using Cryptocurrencies.API.Cryptocurrencies;
using Cryptocurrencies.API.Exceptions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cryptocurrencies.API.Models;

namespace Cryptocurrencies.API.Externals
{
    public class HttpCryptocurrenciesProvider : ICryptocurrenciesProvider
    {
        public HttpCryptocurrenciesProvider()
        {

        }
        private async Task<string> GetResponseUrl(string url)
        {
            using HttpClient client = new();
            client.BaseAddress = new Uri("https://api.coincap.io/v2/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/cryptocurrencies"));
            client.DefaultRequestHeaders.Add("User-Agent", "Cryptocurrencies");
            string json;
            try
            {
                json = await client.GetStringAsync(url);
            }
            catch (HttpRequestException e)
            {
                // _logger.LogInformation($"{url} not found", DateTimeOffset.UtcNow);
                throw new DataNotFoundException(url, e);
            }

            return json;
        }

        private async Task<string> GetTopNCryptocurrenciesJSON(int top)
        {
            string json = await GetResponseUrl($"assets/?limit={top}");
            return json;
        }

        private JToken ParseResults(JObject json)
        {
            var results = json["data"]!;
            return results;
        }

        public async Task<IEnumerable<ShortCryptocurrencyDTO>> GetTopNCryptocurrencies(int top)
        {
            var json = await GetTopNCryptocurrenciesJSON(top);
            var jsonCryptocurrencies = JObject.Parse(json);
            var jCryptocurrencies = ParseResults(jsonCryptocurrencies);
            var cryptocurrenciesDTO = JsonConvert.DeserializeObject<IEnumerable<ShortCryptocurrencyDTO>>(jCryptocurrencies.ToString());
            return cryptocurrenciesDTO!;
        }
    }
}
