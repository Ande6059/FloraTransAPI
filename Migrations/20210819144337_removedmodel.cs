using Microsoft.EntityFrameworkCore.Migrations;

namespace FloraTransAPI.Migrations
{
    public partial class removedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContainerAssignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContainerAssignment",
                columns: table => new
                {
                    ContainerID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerAssignment", x => new { x.ContainerID, x.ClientID });
                    table.ForeignKey(
                        name: "FK_ContainerAssignment_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContainerAssignment_Container_ContainerID",
                        column: x => x.ContainerID,
                        principalTable: "Container",
                        principalColumn: "CCTag",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerAssignment_ClientID",
                table: "ContainerAssignment",
                column: "ClientID");
        }
    }
}
