using Newtonsoft.Json.Linq;

namespace EarnMoney.Models.Requests.EarnMoney.Missions
{
    public class EarnMoneyGetMissionRequest : EarnMoneyBaseRequest
    {
        public override string ToString()
        {
            return $"page=1&limit=100&game_flag=0&channel={Channel}" +
                    $"&version={Version}" +
                    $"&versionCode={VersionCode}" +
                    $"&deviceId={DeviceId}" +
                    $"&randomUUID={RandomUUID}" +
                    $"&token={Token}" +
                    $"&is_vpn={IsVPN}" +
                    $"&is_developer={IsDeveloper}" +
                    $"&cell_mcc={CellMCC}" +
                    $"&gaid={GoogleId}";
        }
    }
}
