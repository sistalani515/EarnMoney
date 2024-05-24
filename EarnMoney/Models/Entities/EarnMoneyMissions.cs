using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarnMoney.Models.Entities
{
    public class EarnMoneyMissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? DeviceId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? MissionId { get; set; }
        public string? Type { get; set; }
        public int Status { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

    }
}
