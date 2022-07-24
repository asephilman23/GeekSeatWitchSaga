using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekSeatWitchSaga.Data.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberKilled",
                table: "Villager",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearKilled",
                table: "Villager",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberKilled",
                table: "Villager");

            migrationBuilder.DropColumn(
                name: "YearKilled",
                table: "Villager");
        }
    }
}
