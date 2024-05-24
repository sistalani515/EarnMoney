using Newtonsoft.Json;

namespace EarnMoney.Models.Responses.EarnMoney.Missions
{
    public class EarnMoneyDoMissionResponse : EarnMoneyBaseResponse
    {
        [JsonProperty("data")]
        public EarnMoneyDoMissionResponseData? Data { get; set; }
    }
    public class EarnMoneyDoMissionResponseData
    {
        [JsonProperty("is_auto_success")]
        public int Status { get; set; }
    }
}
