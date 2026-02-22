using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class ToColumnsAndIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "users",
                newName: "IX_users_email");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "user_profiles",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "user_profiles",
                newName: "birthday");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_profiles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "user_profiles",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "user_profiles",
                newName: "first_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_users_email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "user_profiles",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "user_profiles",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "user_profiles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "user_profiles",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "user_profiles",
                newName: "FirstName");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserInfoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_user_profiles_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "user_profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_UserInfoId",
                table: "products",
                column: "UserInfoId");
        }
    }
}
