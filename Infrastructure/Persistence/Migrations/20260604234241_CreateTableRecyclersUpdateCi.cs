using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecifuturoBackend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRecyclersUpdateCi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "city",
                table: "Recyclers",
                newName: "ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ci",
                table: "Recyclers",
                newName: "city");
        }
    }
}
