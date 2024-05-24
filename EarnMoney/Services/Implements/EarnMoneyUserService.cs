using Dapper;
using EarnMoney.Helpers.Database;
using EarnMoney.Models.Databases;
using EarnMoney.Models.Entities;
using EarnMoney.Models.Responses.EarnMoney.Missions;
using EarnMoney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EarnMoney.Services.Implements
{
    public class EarnMoneyUserService : IEarnMoneyUserService
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<EarnMoneyUserService> logger;

        public EarnMoneyUserService(AppDbContext context, ILogger<EarnMoneyUserService> logger)
        {
            _dbConnection = context.Database.GetDbConnection();
            this.logger = logger;
        }

        public async Task<IEnumerable<EarnMoneyUser>> GetAllUsers()
        {
            try
            {
                string sql = $"Select * from EarnMoneyUsers";
                var result = await _dbConnection.QueryAsync<EarnMoneyUser>(sql);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EarnMoneyUser> GetUserByDeviceId(string deviceId)
        {
            try
            {
                string sql = $"Select * from EarnMoneyUsers where DeviceId='{deviceId}'";
                var result = await _dbConnection.QueryFirstOrDefaultAsync<EarnMoneyUser>(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EarnMoneyUser> GetUserByGoogleId(string googleId)
        {
            try
            {
                string sql = $"Select * from EarnMoneyUsers where GoogleId='{googleId}'";
                var result = await _dbConnection.QueryFirstOrDefaultAsync<EarnMoneyUser>(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> InsertUser(EarnMoneyUser user)
        {
            try
            {
                var existDevice = await GetUserByDeviceId(user.DeviceId!);
                if (existDevice != null) throw new Exception($"User DeviceId : {user.DeviceId!} exist");
                var existGoogle = await GetUserByGoogleId(user.GoogleId!);
                if (existGoogle != null) throw new Exception($"User GoogleId : {user.GoogleId!} exist");
                string sql = SQLQueryHelper.Insert(user);
                var result = await _dbConnection.ExecuteAsync(sql, user);
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateBalanceUser(string deviceId, double balance)
        {
            try
            {
                var exist = await GetUserByDeviceId(deviceId);
                if (exist == null) throw new Exception($"User DeviceId : {deviceId} not exist");
                string sql = $"Update EarnMoneyUsers set Balance = '{balance}' where DeviceId='{exist.DeviceId!}'";
                var result = await _dbConnection.ExecuteAsync(sql);
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> UpdateMissionUser(string deviceId, int missionToday, int finishToday)
        {
            try
            {
                var exist = await GetUserByDeviceId(deviceId);
                if (exist == null) throw new Exception($"User DeviceId : {deviceId} not exist");
                string sql = $"Update EarnMoneyUsers set MissionToday = '{missionToday}', FinishToday='{finishToday}' where DeviceId='{exist.DeviceId!}'";
                var result = await _dbConnection.ExecuteAsync(sql);
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> UpdateStatusWDUser(string deviceId, bool status)
        {
            try
            {
                var exist = await GetUserByDeviceId(deviceId);
                if (exist == null) throw new Exception($"User DeviceId : {deviceId} not exist");
                string sql = $"Update EarnMoneyUsers set IsWD = '{Convert.ToInt32(status)}' where DeviceId='{exist.DeviceId!}'";
                var result = await _dbConnection.ExecuteAsync(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> SetNoHPUser(string deviceId, string noHp)
        {
            try
            {
                var exist = await GetUserByDeviceId(deviceId);
                if (exist == null) throw new Exception($"User DeviceId : {deviceId} not exist");
                string sql = $"Update EarnMoneyUsers set NoHP = '{noHp}' where DeviceId='{exist.DeviceId!}'";
                var result = await _dbConnection.ExecuteAsync(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<int> AddOrUpdateUserMissions(string deviceId, List<EarnMoneyMissions> missions)
        {
            try
            {
                if(missions.Count > 0)
                {
                    foreach(var m in missions)
                    {
                        try
                        {
                            var exist = await GetMissionById(m.DeviceId!, m.MissionId!);
                            if(exist == null)
                            {
                                await InserMissionUser(m);
                            }
                            else
                            {
                                await UpdateMissionUser(m);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EarnMoneyMissions> GetMissionById(string deviceId, string missionId)
        {
            try
            {
                string sql = $"Select * from EarnMoneyMissions where DeviceId='{deviceId}' and MissionId='{missionId}'";
                var result = await _dbConnection.QueryFirstOrDefaultAsync< EarnMoneyMissions>(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> InserMissionUser(EarnMoneyMissions missions)
        {
            try
            {
                    string sql = SQLQueryHelper.Insert(missions);
                    var result = await _dbConnection.ExecuteAsync(sql, missions);
                    return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateMissionUser(EarnMoneyMissions missions)
        {
            try
            {
                    string sql = $"Update EarnMoneyMissions set Status='{missions.Status}'";
                    var result = await _dbConnection.ExecuteAsync(sql, missions);
                    return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EarnMoneyHistoryWD>> GetAllHistoryWD()
        {
            try
            {
                string sql = $"select * from EarnMoneyHistoryWDs";
                var result = await _dbConnection.QueryAsync<EarnMoneyHistoryWD>(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EarnMoneyHistoryWD>> GetHistoryWDByNoHP(string noHp)
        {
            try
            {
                string sql = $"select * from EarnMoneyHistoryWDs where NoDana='{noHp}'";
                var result = await _dbConnection.QueryAsync<EarnMoneyHistoryWD>(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable< EarnMoneyPriorityMission>> GetPriorityMission()
        {
            try
            {
                string sql = $"Select * from EarnMoneyPriorityMissions where Success=1  order by LastUpdate Desc";
                var result = await _dbConnection.QueryAsync<EarnMoneyPriorityMission>(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<EarnMoneyPriorityMission> GetPriorityMissionById(string missionId)
        {
            try
            {
                string sql = $"select * from EarnMoneyPriorityMissions where MissionId='{missionId}' order by LastUpdate Desc";
                var result = await _dbConnection.QueryFirstOrDefaultAsync<EarnMoneyPriorityMission>(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddOrUpdatePriorityMission(string missionId, bool status)
        {
            try
            {
                var exist = await GetPriorityMissionById(missionId);
                if(exist == null)
                {
                    EarnMoneyPriorityMission newM = new EarnMoneyPriorityMission
                    {
                        MissionId = missionId,
                        Success = status
                    };
                    string sql = SQLQueryHelper.Insert(newM);
                    var result = await _dbConnection.ExecuteAsync(sql, newM);
                    return result!;
                }
                else
                {
                    string sql = $"update EarnMoneyPriorityMissions set Success='{Convert.ToInt32(status)}', LastUpdate='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where MissionId='{missionId}'";
                    var result = await _dbConnection.ExecuteAsync(sql);
                    return result!;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }


        public async Task<int> SaveHistoryWD(string deviceId, string noHp, bool status, string response)
        {
            try
            {
                EarnMoneyHistoryWD history = new EarnMoneyHistoryWD
                {
                    DeviceId = deviceId,
                    IsSuccess = status,
                    NoHP = noHp,
                    Response = response
                };
                string sql = SQLQueryHelper.Insert(history);
                var r = await _dbConnection.ExecuteAsync(sql, history);
                logger.LogInformation("Save History");
                return r!;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
