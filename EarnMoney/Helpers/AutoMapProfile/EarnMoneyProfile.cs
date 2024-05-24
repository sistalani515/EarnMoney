using AutoMapper;
using EarnMoney.Models.Entities;
using EarnMoney.Models.Responses.EarnMoney.Missions;

namespace EarnMoney.Helpers.AutoMapProfile
{
    public class EarnMoneyProfile : Profile
    {
        public EarnMoneyProfile()
        {
            CreateMap<EarnMoneyMissions, EarnMoneyGetMissionResponseData>().ReverseMap();
        }
    }
}
