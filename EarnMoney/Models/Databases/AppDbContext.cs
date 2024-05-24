using EarnMoney.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EarnMoney.Models.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public virtual DbSet<MasterDana> MasterDanas { get; set; }
        public virtual DbSet<EarnMoneyUser> EarnMoneyUsers { get; set; }
        public virtual DbSet<EarnMoneyMissions> EarnMoneyMissions { get; set; }
        public virtual DbSet<EarnMoneyHistoryWD> EarnMoneyHistoryWDs { get; set; }
        public virtual DbSet<EarnMoneyPriorityMission> EarnMoneyPriorityMissions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EarnMoneyMissions>().HasKey(e => new { e.DeviceId, e.MissionId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
