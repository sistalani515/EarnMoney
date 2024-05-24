namespace EarnMoney.Models.Requests.EarnMoney.Missions
{
    public class EarnMoneyMissionStartRequest : EarnMoneyBaseRequest
    {
        public string? MissionId { get; set; }
        public int Urut { get; set; } = 0;
        public override string ToString()
        {
            return $"no={MissionId}" +
                    $"{(Urut != 0 ? $"&step={Urut}" : "")}" +
                    $"&channel={Channel}" +
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
