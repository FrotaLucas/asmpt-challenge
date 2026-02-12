using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewPropertyBoardPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderBoards",
                newName: "BoardPosition");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "BoardComponents",
                newName: "BoardPosition");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "OrderBoards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "OrderBoards");

            migrationBuilder.RenameColumn(
                name: "BoardPosition",
                table: "OrderBoards",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "BoardPosition",
                table: "BoardComponents",
                newName: "Quantity");
        }
    }
}
