namespace OnlineBookstore.Entities.Config
{
    using Newtonsoft.Json;

    public class UserSettings
    {
        [JsonProperty("adminCredentials")]
        public AdminCredentials AdminCredentials { get; set; } = null!; 
    }
}
