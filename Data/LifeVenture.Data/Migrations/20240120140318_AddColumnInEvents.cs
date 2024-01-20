using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeVenture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnInEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxParticipantsCount",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxParticipantsCount",
                table: "Events");
        }
    }
}
