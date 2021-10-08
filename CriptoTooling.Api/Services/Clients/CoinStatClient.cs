using CriptoTooling.Api.RequestObjects;
using CriptoTooling.Api.ResponseObjects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CriptoTooling.Api.Services.Clients
{
    public class CoinStatClient
    {
        private HttpClient _client;
        private ILogger<CoinStatClient> _logger;

        public CoinStatClient(HttpClient client, ILogger<CoinStatClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<ConinStatResponse> GetData(CoinStatRequest request)
        {
            try
            {
                if (request.PageSize == default)
                    request.PageSize = 100;

                var path = $"/v1/coins?skip=0&limit={request.PageSize}";
                using var serviceResult = await _client.GetAsync(_client.BaseAddress + path);

                if (!serviceResult.IsSuccessStatusCode)
                    _logger.LogError("errorcito rey");

                var jsonResult = await serviceResult.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ConinStatResponse>(jsonResult);

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
