namespace EarnMoney.Models.Requests.EarnMoney
{
    public class EarnMoneyBaseRequest
    {
        public string? Channel { get; set; } = "jfq_offer";
        public string? Version { get; set; } = "1.0.1.3";
        public string? VersionCode { get; set; } = "10013";
        public string? DeviceId { get; set; } = "";
        public string? RandomUUID { get; set; } = "";
        public string? Token { get; set; } = "";
        public string? IsVPN { get; set; } = "false";
        public string? IsDeveloper { get; set; } = "false";
        public string? CellMCC { get; set; } = "510";
        public string? GoogleId { get; set; } = "";
    }
}
