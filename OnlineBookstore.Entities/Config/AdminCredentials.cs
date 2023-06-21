namespace OnlineBookstore.Entities.Config
{
    using Newtonsoft.Json;

    public class AdminCredentials
    {
        [JsonProperty("username")]
        public string Username { get; set; } = null!;

        [JsonProperty("password")]
        public string Password { get; set; } = null!;
    }
}