using Microsoft.EntityFrameworkCore.Migrations;

namespace FloraTransAPI.Migrations
{
    public partial class revert_manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Container",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Container_ClientID",
                table: "Container",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Container_Client_ClientID",
                table: "Container",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Container_Client_ClientID",
                table: "Container");

            migrationBuilder.DropIndex(
                name: "IX_Container_ClientID",
                table: "Container");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Container");
        }
    }
}
