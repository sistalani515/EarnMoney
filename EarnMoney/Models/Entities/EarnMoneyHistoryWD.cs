using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarnMoney.Models.Entities
{
    public class EarnMoneyHistoryWD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? DeviceId { get; set; }
        public string? NoHP { get; set; }
        public bool IsSuccess { get; set; }
        public string? Response {  get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
