using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeVenture.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Abbreviation",
                table: "Regions",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Regions",
                newName: "Abbreviation");
        }
    }
}
