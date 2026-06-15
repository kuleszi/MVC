using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmEmail",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Kcal",
                table: "Recipes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Portion",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Recipes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Portion",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "Kcal",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
