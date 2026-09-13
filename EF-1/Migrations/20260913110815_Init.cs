using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "AnimalsTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalsTable",
                table: "AnimalsTable",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalsTable",
                table: "AnimalsTable");

            migrationBuilder.RenameTable(
                name: "AnimalsTable",
                newName: "Animals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "Id");
        }
    }
}
