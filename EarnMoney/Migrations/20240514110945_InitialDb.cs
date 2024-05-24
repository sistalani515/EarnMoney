using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EarnMoney.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EarnMoneyUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeviceId = table.Column<string>(type: "TEXT", nullable: true),
                    GoogleId = table.Column<string>(type: "TEXT", nullable: true),
                    Token = table.Column<string>(type: "TEXT", nullable: true),
                    Balance = table.Column<double>(type: "REAL", nullable: false),
                    MissionToday = table.Column<int>(type: "INTEGER", nullable: false),
                    FinishToday = table.Column<int>(type: "INTEGER", nullable: false),
                    IsWD = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoHP = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarnMoneyUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterDanas",
                columns: table => new
                {
                    NoDana = table.Column<string>(type: "TEXT", nullable: false),
                    Nama = table.Column<string>(type: "TEXT", nullable: true),
                    JumlahWD = table.Column<int>(type: "INTEGER", nullable: false),
                    TodayWD = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDanas", x => x.NoDana);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarnMoneyUsers");

            migrationBuilder.DropTable(
                name: "MasterDanas");
        }
    }
}
