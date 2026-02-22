using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ProprertyOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BoardComponents_OrderId",
                table: "BoardComponents",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardComponents_Orders_OrderId",
                table: "BoardComponents",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardComponents_Orders_OrderId",
                table: "BoardComponents");

            migrationBuilder.DropIndex(
                name: "IX_BoardComponents_OrderId",
                table: "BoardComponents");
        }
    }
}
