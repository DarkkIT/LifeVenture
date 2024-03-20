using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeVenture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLikesToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserEvent1",
                columns: table => new
                {
                    LikedEventsId = table.Column<int>(type: "int", nullable: false),
                    UserLikesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserEvent1", x => new { x.LikedEventsId, x.UserLikesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvent1_AspNetUsers_UserLikesId",
                        column: x => x.UserLikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvent1_Events_LikedEventsId",
                        column: x => x.LikedEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvent1_UserLikesId",
                table: "ApplicationUserEvent1",
                column: "UserLikesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserEvent1");
        }
    }
}
