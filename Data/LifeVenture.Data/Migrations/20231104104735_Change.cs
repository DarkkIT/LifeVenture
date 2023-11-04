using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeVenture.Data.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagePeoples_PersonOfGoodnesses_PersonOfGoodnesId",
                table: "ImagePeoples");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagePeoples_Volunteers_VolunteerId",
                table: "ImagePeoples");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Events_EventId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_EventId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_ImagePeoples_PersonOfGoodnesId",
                table: "ImagePeoples");

            migrationBuilder.DropIndex(
                name: "IX_ImagePeoples_VolunteerId",
                table: "ImagePeoples");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Phones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VolunteerId",
                table: "ImagePeoples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonOfGoodnesId",
                table: "ImagePeoples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_EventId",
                table: "Phones",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImagePeoples_PersonOfGoodnesId",
                table: "ImagePeoples",
                column: "PersonOfGoodnesId",
                unique: true,
                filter: "[PersonOfGoodnesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImagePeoples_VolunteerId",
                table: "ImagePeoples",
                column: "VolunteerId",
                unique: true,
                filter: "[VolunteerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePeoples_PersonOfGoodnesses_PersonOfGoodnesId",
                table: "ImagePeoples",
                column: "PersonOfGoodnesId",
                principalTable: "PersonOfGoodnesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePeoples_Volunteers_VolunteerId",
                table: "ImagePeoples",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Events_EventId",
                table: "Phones",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagePeoples_PersonOfGoodnesses_PersonOfGoodnesId",
                table: "ImagePeoples");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagePeoples_Volunteers_VolunteerId",
                table: "ImagePeoples");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Events_EventId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_EventId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_ImagePeoples_PersonOfGoodnesId",
                table: "ImagePeoples");

            migrationBuilder.DropIndex(
                name: "IX_ImagePeoples_VolunteerId",
                table: "ImagePeoples");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VolunteerId",
                table: "ImagePeoples",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonOfGoodnesId",
                table: "ImagePeoples",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_EventId",
                table: "Phones",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagePeoples_PersonOfGoodnesId",
                table: "ImagePeoples",
                column: "PersonOfGoodnesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagePeoples_VolunteerId",
                table: "ImagePeoples",
                column: "VolunteerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePeoples_PersonOfGoodnesses_PersonOfGoodnesId",
                table: "ImagePeoples",
                column: "PersonOfGoodnesId",
                principalTable: "PersonOfGoodnesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePeoples_Volunteers_VolunteerId",
                table: "ImagePeoples",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Events_EventId",
                table: "Phones",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
