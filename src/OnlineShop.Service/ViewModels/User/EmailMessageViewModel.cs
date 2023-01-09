using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OnlineShop.Service.ViewModels.User
{
    public class EmailMessageViewModel
    {
        [JsonPropertyName("to")]
        public string To { get; set; } = String.Empty;
        [JsonProperty(PropertyName = "body")]
        public int Body { get; set; }
        [JsonPropertyName("subject")]
        public string Subject { get; set; } = String.Empty;
    }
}


