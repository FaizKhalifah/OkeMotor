using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkeMotor.Migrations
{
    /// <inheritdoc />
    public partial class Addingpricetomotormodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "motors",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "motors");
        }
    }
}
