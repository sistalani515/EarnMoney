namespace EarnMoney.Models.Requests.EarnMoney.Missions
{
    public class EarnMonyeCheckMissionRequest : EarnMoneyBaseRequest
    {
        public override string ToString()
        {
            return  $"channel={Channel}" +
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
