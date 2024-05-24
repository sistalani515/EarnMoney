using Newtonsoft.Json;

namespace EarnMoney.Models.Responses.EarnMoney.Missions
{
    public class EarnMonyeCheckMissionResponse : EarnMoneyBaseResponse
    {
        [JsonProperty("data")]
        public EarnMonyeCheckMissionResponseData? Data { get; set; }
    }
    public class EarnMonyeCheckMissionResponseData
    {
        [JsonProperty("completion_conditions")]
        public int Condistion { get; set; }
        [JsonProperty("success_conditions")]
        public int Complete { get; set; }
        [JsonProperty("money")]
        public double Money { get; set; }
    }
}
