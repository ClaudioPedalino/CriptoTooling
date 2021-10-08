using CriptoTooling.Api.RequestObjects;
using CriptoTooling.Api.ResponseObjects;
using CriptoTooling.Api.Services.Clients;
using System.Threading.Tasks;

namespace CriptoTooling.Api.Interfaces
{
    public interface ITrackerService
    {
        Task<ConinStatResponse> GetData(CoinStatRequest request);
        Task<CoinMarketCapResponse> GetGainersLosers(CoinMarketCapRequest request);
    }
}
