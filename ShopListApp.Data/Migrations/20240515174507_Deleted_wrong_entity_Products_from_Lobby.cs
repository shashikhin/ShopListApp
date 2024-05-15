using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopListApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Deleted_wrong_entity_Products_from_Lobby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Lobbys_LobbyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LobbyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LobbyId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LobbyId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_LobbyId",
                table: "Products",
                column: "LobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Lobbys_LobbyId",
                table: "Products",
                column: "LobbyId",
                principalTable: "Lobbys",
                principalColumn: "Id");
        }
    }
}
