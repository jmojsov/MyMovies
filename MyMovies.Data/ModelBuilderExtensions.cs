using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Bad Boys for Life ",
                    Description = "Miami detectives Mike Lowrey and Marcus Burnett must face off against " +
                    "a mother-and-son pair of drug lords who wreak vengeful havoc on their city.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMWU0MGYwZWQtMzcwYS00NWVhLTlkZTAtYWVjOTYwZTBhZTBiXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Cast = "Will Smith, Martin Lawrence, Vanessa Hudgens ",
                    Genre = "action"
                });
        }
    }
}
