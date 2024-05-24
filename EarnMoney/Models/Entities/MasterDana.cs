using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EarnMoney.Models.Entities
{
    public class MasterDana
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? NoDana { get; set; }
        public string? Nama { get; set; }
        public int JumlahWD { get; set; }
        public bool TodayWD { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
