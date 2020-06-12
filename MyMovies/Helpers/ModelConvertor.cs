using MyMovies.Data;
using MyMovies.ViewModels;
using System;
using System.Linq;

namespace MyMovies.Helpers
{
    public static class ModelConvertor
    {
        public static MovieOverviewModel ConvertToOverviewModel(Movie movie)
        {
            var overviewModel = new MovieOverviewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                DaysCreated = DateTime.Now.Subtract(movie.DateCreated.Value).Days
            };

            return overviewModel;
        }

        public static MovieDetailsModel ConvertToMovieDetailsModel(Movie movie)
        {
            return new MovieDetailsModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Cast = movie.Cast,
                Genre = movie.Genre,
                DateCreated = movie.DateCreated,
                Views = movie.Views,
                MovieComments = movie.MovieComments.Select(x => ConvertToMovieCommentModel(x)).ToList()
            };
        }

        private static MovieCommentModel ConvertToMovieCommentModel(MovieComment movieComment)
        {
            return new MovieCommentModel
            {
                Comment = movieComment.Comment,
                DateCreated = movieComment.DateCreated,
                Username = movieComment.User.Username
            };
        }

        public static Movie ConvertFromCreateModel(MovieCreateModel createMovie)
        {
            return new Movie
            {
                Title = createMovie.Title,
                Description = createMovie.Description,
                ImageUrl = createMovie.ImageUrl,
                Cast = createMovie.Cast,
                Genre = createMovie.Genre
            };
        }

        public static MovieModifyModel ConvertToMovieModifyModel(Movie movie)
        {
            return new MovieModifyModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Cast = movie.Cast,
                Genre = movie.Genre,
                DateCreated = movie.DateCreated,
                Views = movie.Views
            };
        }

        public static ModifyOverviewModel ConverToModifyOverviewModel(Movie movie)
        {
            return new ModifyOverviewModel
            {
                Id = movie.Id,
                Title = movie.Title
            };
        }

        public static Movie ConvertFromMoviesModifyModel(MovieModifyModel movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Cast = movie.Cast,
                Genre = movie.Genre,
                DateCreated = movie.DateCreated,
                Views = movie.Views
            };
        }
    }
}
