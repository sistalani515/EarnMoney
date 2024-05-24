using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarnMoney.Models.Entities
{
    public class EarnMoneyPriorityMission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? MissionId { get; set; }
        public bool Success { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
