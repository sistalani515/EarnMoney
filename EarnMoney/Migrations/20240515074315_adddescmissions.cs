using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EarnMoney.Migrations
{
    /// <inheritdoc />
    public partial class adddescmissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EarnMoneyMissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EarnMoneyMissions",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "EarnMoneyMissions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "EarnMoneyMissions");
        }
    }
}
