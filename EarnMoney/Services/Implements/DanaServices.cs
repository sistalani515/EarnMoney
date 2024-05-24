
using Dapper;
using EarnMoney.Helpers.Database;
using EarnMoney.Models.Databases;
using EarnMoney.Models.Entities;
using EarnMoney.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EarnMoney.Services.Implements
{
    public class DanaServices : IDanaService
    {
        private readonly IDbConnection _dbConnection;
        public DanaServices(AppDbContext context)
        {
            _dbConnection = context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<MasterDana>> GetAllMasterDana()
        {
            try
            {
                string sql = $"Select * from MasterDanas";
                var result = await _dbConnection.QueryAsync<MasterDana>(sql);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MasterDana> GetMasterDanaByNomor(string noHp)
        {
            try
            {
                string sql = $"Select * from MasterDanas where NoDana='{noHp}'";
                var result = await _dbConnection.QueryFirstOrDefaultAsync<MasterDana>(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> InsertMasterDana(MasterDana masterDana)
        {
            try
            {
                var exist = await GetMasterDanaByNomor(masterDana.NoDana!);
                if (exist != null) throw new Exception("Dana exist");
                string sql = SQLQueryHelper.Insert(masterDana);
                var result = await _dbConnection.ExecuteAsync(sql, masterDana);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> ToggleStatusDana(string noHp, bool status)
        {
            try
            {
                var exist = await GetMasterDanaByNomor(noHp);
                if (exist == null) throw new Exception("Dana not exist");
                string sql = $"Update MasterDanas set IsActive='{Convert.ToInt32(status)}' where NoDana='{noHp}'";
                var result = await _dbConnection.ExecuteAsync(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> ToggleWDDana(string noHp)
        {
            try
            {
                var exist = await GetMasterDanaByNomor(noHp);
                if (exist == null) throw new Exception("Dana not exist");
                string sql = $"Update MasterDanas set TodayWD='{Convert.ToInt32(true)}' where NoDana='{noHp}'";
                var result = await _dbConnection.ExecuteAsync(sql);
                if (result == 1) await UpdateWDDana(noHp);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<int> UpdateWDDana(string noHp)
        {
            try
            {
                var exist = await GetMasterDanaByNomor(noHp);
                if (exist == null) throw new Exception("Dana not exist");
                string sql = $"Update MasterDanas set JumlahWD= JumlahWD + 1 where NoDana='{noHp}'";
                var result = await _dbConnection.ExecuteAsync(sql);
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
