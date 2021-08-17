using Microsoft.EntityFrameworkCore.Migrations;

namespace FloraTransAPI.Migrations
{
    public partial class currentClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentClient",
                table: "Container",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentClient",
                table: "Container");
        }
    }
}
