using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Data.Migrations
{
    public partial class addedmovieId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_Movies_MovieID",
                table: "MovieComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_Users_UserId",
                table: "MovieComments");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "MovieComments",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComments_MovieID",
                table: "MovieComments",
                newName: "IX_MovieComments_MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MovieComments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_Movies_MovieId",
                table: "MovieComments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_Users_UserId",
                table: "MovieComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_Movies_MovieId",
                table: "MovieComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_Users_UserId",
                table: "MovieComments");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieComments",
                newName: "MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComments_MovieId",
                table: "MovieComments",
                newName: "IX_MovieComments_MovieID");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MovieComments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_Movies_MovieID",
                table: "MovieComments",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_Users_UserId",
                table: "MovieComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
