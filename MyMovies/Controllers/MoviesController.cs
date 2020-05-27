using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
using MyMovies.Services;
using MyMovies.Services.Interfaces;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        public IMoviesService MoviesService { get; set; }

        public MoviesController(IMoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        public IActionResult Overview(string title)
        {
            var movies = MoviesService.GetByTitle(title);

            return View(movies);
        }

        public IActionResult Create()
        {
            var movie = new Movie();
            return View(movie);
        }

        public IActionResult Details(int id)
        {
            var movie = MoviesService.GetById(id);

            return View(movie);
        }

        

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                MoviesService.CreateMovie(movie);
                return RedirectToAction("Overview");

            }
            else
            {
                return View(movie);
            }
        }
    }
}