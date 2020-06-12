using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;

namespace MyMovies.Controllers
{
    public class MovieCommentsController : Controller
    {
        public MovieCommentsController(IMovieCommentService movieCommentService)
        {
            MovieCommentService = movieCommentService;
        }

        public IMovieCommentService MovieCommentService { get; }
        [Authorize]
        public IActionResult Add(string comment, int movieId)
        {
            if (!string.IsNullOrEmpty(comment))
            {
                var userId = Convert.ToInt32(User.FindFirst("Id").Value);
                MovieCommentService.Add(comment, movieId, userId);
            }
            return RedirectToAction("Details", "Movies", new { id = movieId });

        }
    }
}