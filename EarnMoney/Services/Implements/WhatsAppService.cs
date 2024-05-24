using EarnMoney.Models.Requests.WhatsApp;
using EarnMoney.Services.Interfaces;

namespace EarnMoney.Services.Implements
{
    public class WhatsAppService
    {
        private readonly IEarnMoneyService earnMoneyService;
        private readonly IEarnMoneyUserService earnMoneyUserService;

        public WhatsAppService(IEarnMoneyService earnMoneyService, IEarnMoneyUserService earnMoneyUserService)
        {
            this.earnMoneyService = earnMoneyService;
            this.earnMoneyUserService = earnMoneyUserService;
        }

        public async Task ListenWebhook(WhatsAppReqBody body)
        {
            try
            {
                var sender = body.Data!.From!;
                var typeMsg = body.Data!.Type;
                if (sender == "6287759895339@c.us" && typeMsg == "chat")
                {
                    var msg = body.Data!.Text!;
                    if (msg.StartsWith("#"))
                    {
                        var actualMsg = msg.Replace("#","");
                        if (actualMsg.Contains("WD"))
                        {
                            var nomor = actualMsg.Replace("WD-", "");
                            await earnMoneyService.DoAutoWithdrawUser(nomor);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
