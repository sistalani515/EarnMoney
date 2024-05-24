using Newtonsoft.Json;

namespace EarnMoney.Models.Responses.EarnMoney.Missions
{
    public class EarnMoneyGetMissionResponse : EarnMoneyBaseResponse
    {
        [JsonProperty("data")]
        public List<EarnMoneyGetMissionResponseData>? Data { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class EarnMoneyGetMissionResponseData
    {
        [JsonProperty("no")]
        public string? MissionId { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("app_name")]
        public string? Name { get; set; }
        [JsonProperty("name")]
        public string? Description { get; set; }
        [JsonProperty("deviceId")]
        public string? DeviceId { get; set; }
    }
}
