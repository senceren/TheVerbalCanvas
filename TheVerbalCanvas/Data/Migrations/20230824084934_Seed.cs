using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheVerbalCanvas.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Context",
                table: "Posts",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Posts",
                newName: "Context");
        }
    }
}
