using CriptoTooling.Api.Interfaces;
using CriptoTooling.Api.RequestObjects;
using CriptoTooling.Api.ResponseObjects;
using CriptoTooling.Api.Services.Clients;
using System.Linq;
using System.Threading.Tasks;

namespace CriptoTooling.Api.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly CoinStatClient _coinStatClient;
        private readonly CoinMarketCapClient _coinMarketCapClient;

        public TrackerService(CoinStatClient coinStatClient, CoinMarketCapClient coinMarketCapClient)
        {
            _coinStatClient = coinStatClient;
            _coinMarketCapClient = coinMarketCapClient;
        }

        public async Task<ConinStatResponse> GetData(CoinStatRequest request)
        {
            var response = await _coinStatClient.GetData(request);
            response.Total = response.Coins.Count();

            return response;
        }

        public async Task<CoinMarketCapResponse> GetGainersLosers(CoinMarketCapRequest request)
        {
            var response = await _coinMarketCapClient.GetGainersLosers(request);

            return response;
        }
    }
}
