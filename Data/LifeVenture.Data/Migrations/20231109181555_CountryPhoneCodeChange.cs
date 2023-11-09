using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeVenture.Data.Migrations
{
    /// <inheritdoc />
    public partial class CountryPhoneCodeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CountriesPhoneCodes_IsDeleted",
                table: "CountriesPhoneCodes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CountriesPhoneCodes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CountriesPhoneCodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CountriesPhoneCodes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CountriesPhoneCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CountriesPhoneCodes_IsDeleted",
                table: "CountriesPhoneCodes",
                column: "IsDeleted");
        }
    }
}
