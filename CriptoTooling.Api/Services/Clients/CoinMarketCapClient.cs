using CriptoTooling.Api.RequestObjects;
using CriptoTooling.Api.ResponseObjects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CriptoTooling.Api.Services.Clients
{
    public class CoinMarketCapClient
    {
        private HttpClient _client;
        private ILogger<CoinMarketCapClient> _logger;

        public CoinMarketCapClient(HttpClient client, ILogger<CoinMarketCapClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<CoinMarketCapResponse> GetGainersLosers(CoinMarketCapRequest request)
        {
            try
            {
                var path = $"/data-api/v3/cryptocurrency/spotlight" +
                    $"?dataType={request.DataType}" +
                    $"&limit={request.Limit}" +
                    $"&rankRange={request.RankRange}" +
                    $"&timeframe={request.TimeFrame}";

                using var serviceResult = await _client.GetAsync(_client.BaseAddress + path);

                if (!serviceResult.IsSuccessStatusCode)
                    _logger.LogError("errorcito rey");

                var jsonResult = await serviceResult.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<CoinMarketCapResponse>(jsonResult);

                return response;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"An error occurred connecting to {nameof(CoinStatClient)} API {ex}");
                throw;
            }
        }
    }

}
