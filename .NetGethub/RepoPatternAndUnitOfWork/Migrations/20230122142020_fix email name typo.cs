using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoPatternAndUnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class fixemailnametypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Eamil",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Eamil");
        }
    }
}
