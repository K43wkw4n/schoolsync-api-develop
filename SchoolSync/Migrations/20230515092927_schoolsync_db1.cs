using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSync.Migrations
{
    /// <inheritdoc />
    public partial class schoolsync_db1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Division_DivisionId",
                table: "Position");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Position",
                newName: "DivisionCode");

            migrationBuilder.RenameIndex(
                name: "IX_Position_DivisionId",
                table: "Position",
                newName: "IX_Position_DivisionCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Division_DivisionCode",
                table: "Position",
                column: "DivisionCode",
                principalTable: "Division",
                principalColumn: "DivisionCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Division_DivisionCode",
                table: "Position");

            migrationBuilder.RenameColumn(
                name: "DivisionCode",
                table: "Position",
                newName: "DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Position_DivisionCode",
                table: "Position",
                newName: "IX_Position_DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Division_DivisionId",
                table: "Position",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "DivisionCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
