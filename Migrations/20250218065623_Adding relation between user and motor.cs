using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkeMotor.Migrations
{
    /// <inheritdoc />
    public partial class Addingrelationbetweenuserandmotor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "motors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_motors_SellerId",
                table: "motors",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_motors_AspNetUsers_SellerId",
                table: "motors",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_motors_AspNetUsers_SellerId",
                table: "motors");

            migrationBuilder.DropIndex(
                name: "IX_motors_SellerId",
                table: "motors");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "motors");
        }
    }
}
