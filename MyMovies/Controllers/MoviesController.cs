using Microsoft.AspNetCore.Mvc;
using MyMovies.Data;
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
        public IActionResult Details(int id)
        {
            var movies = MoviesService.GetMovieDetails(id);

            return View(movies);
        }
        public IActionResult Create()
        {
            var movie = new Movie();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                MoviesService.CreateMovie(movie);
                return RedirectToAction("ModifyOverview");

            }
            else
            {
                return View(movie);
            }
        }
        public IActionResult ModifyOverview()
        {
            var movies = MoviesService.GetAll();
            return View(movies);
        }
        public IActionResult Modify(int id)
        {
            var movie = MoviesService.GetById(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Modify(Movie movie)
        {
            if (ModelState.IsValid)
            {
                MoviesService.UpdateMovie(movie);
                return RedirectToAction("ModifyOverview");
            }
            return View(movie);
        }
        public IActionResult Delete(int id)
        {
            MoviesService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }
    }
}