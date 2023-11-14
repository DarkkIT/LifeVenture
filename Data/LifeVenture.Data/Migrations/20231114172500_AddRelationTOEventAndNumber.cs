using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeVenture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationTOEventAndNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Events_EventId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_EventId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Phones");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PhoneId",
                table: "Events",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Phones_PhoneId",
                table: "Events",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Phones_PhoneId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PhoneId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_EventId",
                table: "Phones",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Events_EventId",
                table: "Phones",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
