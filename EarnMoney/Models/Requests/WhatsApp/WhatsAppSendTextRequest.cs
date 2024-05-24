using Newtonsoft.Json;

namespace EarnMoney.Models.Requests.WhatsApp
{
    public class WhatsAppSendTextRequest
    {
        [JsonProperty("phone")]
        public string? Phone {  get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }

    }
}
