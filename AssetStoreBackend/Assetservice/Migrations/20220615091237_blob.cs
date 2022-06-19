using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetService.Migrations
{
    public partial class blob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileLocation",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Users",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Assets",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "FileName",
                table: "Assets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Users",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Assets",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "FileLocation",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
