using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class SetDefaultSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "users",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "user_profiles",
                newName: "user_profiles",
                newSchema: "auth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "users",
                schema: "auth",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "user_profiles",
                schema: "auth",
                newName: "user_profiles");
        }
    }
}
