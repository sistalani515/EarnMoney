using Newtonsoft.Json;

namespace EarnMoney.Models.Responses.EarnMoney
{
    public class EarnMoneyBaseResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("msg")]
        public string? Message { get; set; }
        public string? DeviceId { get; set; }
        public string? NoDana { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
