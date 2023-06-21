namespace OnlineBookstoreAPI.Models
{
    using Newtonsoft.Json;

    public class Quote
    {
        [JsonProperty("text")]
        public string Text { get; set; } = null!;

        [JsonProperty("author")]
        public string? Author { get; set; }
    }
}
