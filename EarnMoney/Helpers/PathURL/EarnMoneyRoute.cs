﻿namespace EarnMoney.Helpers.PathURL
{
    public class EarnMoneyRoute
    {
        public static readonly string BaseUrl = "https://admin.tgldy.xyz/";

        public static readonly string GetListMission = "app/retrieveOfferList";
        public static readonly string MissionStepOne = "app/startOffer";
        public static readonly string MissionStepTwo = "app/getOfferStepBak";
        public static readonly string MissionStepThree = "app/checkOfferRemainFlag";
        public static readonly string MissionStepFour = "/app/submitOffer";
        public static readonly string Withdraw = "app/getUserTixian_v1";
        public static readonly string CheckCompleteMission = "app/get_user_smailpay";
    }
}
