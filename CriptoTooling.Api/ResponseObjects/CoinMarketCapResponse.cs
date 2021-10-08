using Newtonsoft.Json;
using System.Collections.Generic;

namespace CriptoTooling.Api.ResponseObjects
{
    public class CoinMarketCapResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("gainerList")]
        public List<ErList> GainerList { get; set; }

        [JsonProperty("loserList")]
        public List<ErList> LoserList { get; set; }
    }

    public class ErList
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("priceChange")]
        public PriceChange PriceChange { get; set; }
    }

    public class PriceChange
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("priceChange1h")]
        public decimal PriceChange1H { get; set; }

        [JsonProperty("priceChange24h")]
        public decimal PriceChange24H { get; set; }

        //[JsonProperty("priceChange7d")]
        //public double PriceChange7D { get; set; }

        //[JsonProperty("priceChange30d")]
        //public double PriceChange30D { get; set; }

        //[JsonProperty("volume24h")]
        //public double Volume24H { get; set; }
    }
}
