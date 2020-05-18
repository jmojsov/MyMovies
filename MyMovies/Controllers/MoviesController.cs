using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
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

        public IActionResult Overview()
        {
            var movies = MoviesService.GetAll();

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = MoviesService.GetById(id);

            return View(movie);
        }

        public IActionResult Create()
        {
            var movie = new Movie();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            return RedirectToAction("Overview");
        }
    }
}