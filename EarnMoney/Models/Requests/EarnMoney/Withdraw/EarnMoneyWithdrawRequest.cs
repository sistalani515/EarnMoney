using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace EarnMoney.Models.Requests.EarnMoney.Withdraw
{
    public class EarnMoneyWithdrawRequest : EarnMoneyBaseRequest
    {
        public string? NoDana {  get; set; }
        public override string ToString()
        {
            return $"payee_documentType=&payee_documentType2=&payee_documentType3=&payee_documentId=&payee_documentId2=&payee_documentId3=" +
                                $"&bank=DANA" +
                                $"&pay_account={NoDana}" +
                                $"&real_name=bdhdhd" +
                                $"&money=400.0&jf=600&id=187&channel=jfq_offer&version=1.0.1.3&versionCode=10013" +
                                $"&deviceId={DeviceId}&randomUUID=" +
                                $"&token={Token}" +
                                $"&is_vpn=false&is_developer=false&cell_mcc=510" +
                                $"&gaid={GoogleId}";
        }
    }
}
