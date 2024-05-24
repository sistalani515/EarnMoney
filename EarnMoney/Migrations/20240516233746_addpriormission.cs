using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EarnMoney.Migrations
{
    /// <inheritdoc />
    public partial class addpriormission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EarnMoneyPriorityMissions",
                columns: table => new
                {
                    MissionId = table.Column<string>(type: "TEXT", nullable: false),
                    Success = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarnMoneyPriorityMissions", x => x.MissionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarnMoneyPriorityMissions");
        }
    }
}
