using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderBoards",
                table: "OrderBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardComponents",
                table: "BoardComponents");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderBoards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderBoards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BoardComponents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BoardComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderBoards",
                table: "OrderBoards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardComponents",
                table: "BoardComponents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBoards_OrderId",
                table: "OrderBoards",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardComponents_BoardId",
                table: "BoardComponents",
                column: "BoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderBoards",
                table: "OrderBoards");

            migrationBuilder.DropIndex(
                name: "IX_OrderBoards_OrderId",
                table: "OrderBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardComponents",
                table: "BoardComponents");

            migrationBuilder.DropIndex(
                name: "IX_BoardComponents_BoardId",
                table: "BoardComponents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderBoards");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderBoards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BoardComponents");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BoardComponents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderBoards",
                table: "OrderBoards",
                columns: new[] { "OrderId", "BoardId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardComponents",
                table: "BoardComponents",
                columns: new[] { "BoardId", "ComponentId" });
        }
    }
}
