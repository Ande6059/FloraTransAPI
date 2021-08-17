using Microsoft.EntityFrameworkCore.Migrations;

namespace FloraTransAPI.Migrations
{
    public partial class namechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Client",
                newName: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Client",
                newName: "ID");
        }
    }
}
