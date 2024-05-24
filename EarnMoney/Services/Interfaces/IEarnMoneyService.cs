using EarnMoney.Models.Entities;
using EarnMoney.Models.Responses.EarnMoney;
using EarnMoney.Models.Responses.EarnMoney.Missions;

namespace EarnMoney.Services.Interfaces
{
    public interface IEarnMoneyService
    {
        Task<EarnMoneyGetMissionResponse> GetUserMissions(string deviceId);
        Task<EarnMoneyDoMissionResponse> DoAutoMission(string deviceId, string missionId, int success);
        Task<EarnMoneyBaseResponse> DoWithdrawUser(string deviceId, string noHp);
        Task StartNewUser(string deviceId, string googleId, string token);
        Task ContinueMissionById(string deviceId);
        Task<EarnMonyeCheckMissionResponse> CheckCompleteMission(string deviceId);
        Task<int> DoAutoWithdrawUser(string noHp);
        Task<int> AutoCheckCompleteMission();
    }
}
