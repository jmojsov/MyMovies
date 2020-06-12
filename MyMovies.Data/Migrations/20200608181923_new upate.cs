using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Data.Migrations
{
    public partial class newupate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "MovieComments");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "MovieComments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "MovieComments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "MovieComments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "MovieComments");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "MovieComments",
                nullable: true);
        }
    }
}
