namespace LifeVenture.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Phones_PhoneId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PhoneId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Phones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonOfGoodnessId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VolunteerId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PeopleOfGoodness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldOfWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleOfGoodness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagePeoples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PersonOfGoodnesId = table.Column<int>(type: "int", nullable: false),
                    VolunteerId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePeoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagePeoples_PeopleOfGoodness_PersonOfGoodnesId",
                        column: x => x.PersonOfGoodnesId,
                        principalTable: "PeopleOfGoodness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImagePeoples_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_EventId",
                table: "Phones",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonOfGoodnessId",
                table: "AspNetUsers",
                column: "PersonOfGoodnessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VolunteerId",
                table: "AspNetUsers",
                column: "VolunteerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagePeoples_IsDeleted",
                table: "ImagePeoples",
                column: "IsDeleted");

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

            migrationBuilder.CreateIndex(
                name: "IX_PeopleOfGoodness_IsDeleted",
                table: "PeopleOfGoodness",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IsDeleted",
                table: "Volunteers",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PeopleOfGoodness_PersonOfGoodnessId",
                table: "AspNetUsers",
                column: "PersonOfGoodnessId",
                principalTable: "PeopleOfGoodness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Volunteers_VolunteerId",
                table: "AspNetUsers",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_AspNetUsers_UserId",
                table: "Phones",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Events_EventId",
                table: "Phones",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PeopleOfGoodness_PersonOfGoodnessId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Volunteers_VolunteerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_AspNetUsers_UserId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Events_EventId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "ImagePeoples");

            migrationBuilder.DropTable(
                name: "PeopleOfGoodness");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Phones_EventId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_UserId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonOfGoodnessId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VolunteerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonOfGoodnessId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VolunteerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Name");

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
    }
}
