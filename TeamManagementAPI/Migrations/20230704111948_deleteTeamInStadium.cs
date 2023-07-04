using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class deleteTeamInStadium : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_IdStadium",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_IdStadium",
                table: "Teams",
                column: "IdStadium");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_IdStadium",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_IdStadium",
                table: "Teams",
                column: "IdStadium",
                unique: true);
        }
    }
}
