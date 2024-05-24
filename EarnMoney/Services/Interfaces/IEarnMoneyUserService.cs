using EarnMoney.Models.Entities;

namespace EarnMoney.Services.Interfaces
{
    public interface IEarnMoneyUserService
    {
        Task<IEnumerable<EarnMoneyUser>> GetAllUsers();
        Task<EarnMoneyUser> GetUserByDeviceId(string deviceId);
        Task<EarnMoneyUser> GetUserByGoogleId(string googleId);
        Task<int> InsertUser(EarnMoneyUser user);
        Task<int> UpdateBalanceUser(string deviceId, double balance);
        Task<int> UpdateMissionUser(string deviceId, int missionToday, int finishToday);
        Task<int> UpdateStatusWDUser(string deviceId, bool status);
        Task<int> SetNoHPUser(string deviceId, string noHp);
        Task<int> AddOrUpdateUserMissions(string deviceId, List<EarnMoneyMissions> missions);
        Task<EarnMoneyMissions> GetMissionById(string deviceId, string missionId);
        Task<int> SaveHistoryWD(string deviceId, string noHp, bool status, string response);
        Task<IEnumerable<EarnMoneyPriorityMission>> GetPriorityMission();
        //Task<EarnMoneyPriorityMission> GetPriorityMissionById(string missionId);
        Task<int> AddOrUpdatePriorityMission(string missionId, bool status);
    }
}
