using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecifuturoBackend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRecyclersUpdateCiUpper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ci",
                table: "Recyclers",
                newName: "Ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ci",
                table: "Recyclers",
                newName: "ci");
        }
    }
}
