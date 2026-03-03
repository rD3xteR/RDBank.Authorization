using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserIdField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_profiles_users_UserId",
                schema: "auth",
                table: "user_profiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "auth",
                table: "user_profiles",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_profiles_UserId",
                schema: "auth",
                table: "user_profiles",
                newName: "IX_user_profiles_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_profiles_users_user_id",
                schema: "auth",
                table: "user_profiles",
                column: "user_id",
                principalSchema: "auth",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_profiles_users_user_id",
                schema: "auth",
                table: "user_profiles");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "auth",
                table: "user_profiles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_profiles_user_id",
                schema: "auth",
                table: "user_profiles",
                newName: "IX_user_profiles_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_profiles_users_UserId",
                schema: "auth",
                table: "user_profiles",
                column: "UserId",
                principalSchema: "auth",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
