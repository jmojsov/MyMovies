using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class MovieCommentService : IMovieCommentService
    {
        public MovieCommentService(IMovieCommentRepository movieCommentRepository)
        {
            MovieCommentRepository = movieCommentRepository;
        }

        private IMovieCommentRepository MovieCommentRepository { get; }

        public void Add(string comment, int movieId, int userId)
        {
            var movieComment = new MovieComment();
            movieComment.Comment = comment;
            movieComment.MovieId = movieId;
            movieComment.UserId = userId;
            movieComment.DateCreated = DateTime.Now;

            MovieCommentRepository.Add(movieComment);

        }
    }
}
