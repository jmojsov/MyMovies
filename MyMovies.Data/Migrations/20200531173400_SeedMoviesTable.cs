using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Data.Migrations
{
    public partial class SeedMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Cast", "DateCreated", "Description", "Genre", "ImageUrl", "Title", "Views" },
                values: new object[] { 1, "Will Smith, Martin Lawrence, Vanessa Hudgens ", null, "Miami detectives Mike Lowrey and Marcus Burnett must face off against a mother-and-son pair of drug lords who wreak vengeful havoc on their city.", "action", "https://m.media-amazon.com/images/M/MV5BMWU0MGYwZWQtMzcwYS00NWVhLTlkZTAtYWVjOTYwZTBhZTBiXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_UX182_CR0,0,182,268_AL_.jpg", "Bad Boys for Life ", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
