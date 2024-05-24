using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Web;
using Newtonsoft.Json;

namespace EarnMoney.Models.Entities
{
    public class EarnMoneyUser
    {
        [Key]
        public int Id { get; set; }
        public string? DeviceId { get; set; }
        public string? GoogleId { get; set; }
        public string? Token {  get; set; }
        public double Balance { get; set; }
        public int MissionToday { get; set; }
        public int FinishToday { get; set; }
        public bool IsWD {  get; set; }
        public string? NoHP { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static EarnMoneyUser ParseFromRaw(string raw)
        {
            NameValueCollection parsedData = HttpUtility.ParseQueryString(raw);
            return new EarnMoneyUser
            {
                DeviceId = parsedData["deviceId"],
                GoogleId = parsedData["gaid"],
                Token = parsedData["token"]
            };
        }
    }
}
