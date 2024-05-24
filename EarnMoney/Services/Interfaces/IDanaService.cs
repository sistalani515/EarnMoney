using EarnMoney.Models.Entities;

namespace EarnMoney.Services.Interfaces
{
    public interface IDanaService
    {
        Task<IEnumerable<MasterDana>> GetAllMasterDana();
        Task<MasterDana> GetMasterDanaByNomor(string noHp);
        Task<int> InsertMasterDana(MasterDana masterDana);
        Task<int> ToggleStatusDana(string noHp, bool status);
        Task<int> ToggleWDDana(string noHp);
    }
}
