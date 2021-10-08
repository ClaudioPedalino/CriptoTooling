using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CriptoTooling.Api.ResponseObjects
{
    public class ConinStatResponse
    {
        public int Total { get; set; }

        [JsonProperty("coins")]
        public IEnumerable<CoinElement> Coins { get; set; }
    }

    public class CoinElement
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("icon")]
        public Uri Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("priceChange1h")]
        public decimal PriceChange1H { get; set; }

        [JsonProperty("priceChange1d")]
        public decimal PriceChange1D { get; set; }
    }
}
