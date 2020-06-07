using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Helpers;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        public IMoviesService MoviesService { get; set; }

        public MoviesController(IMoviesService moviesService)
        {
            MoviesService = moviesService;
        }
        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            var movies = MoviesService.GetByTitle(title);
            var overviewViewModels = movies
                .Select(x => ModelConvertor.ConvertToOverviewModel(x))
                .ToList();

            return View(overviewViewModels);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var movie = MoviesService.GetMovieDetails(id);

            var movieDetails = ModelConvertor.ConvertToMovieDetailsModel(movie);

            return View(movieDetails);
        }
        public IActionResult Create()
        {
            var movie = new MovieCreateModel();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateModel createMovie)
        {
            if (ModelState.IsValid)
            {
                var movie = ModelConvertor.ConvertFromCreateModel(createMovie);
                MoviesService.CreateMovie(movie);
                return RedirectToAction("ModifyOverview");

            }
            else
            {
                return View(createMovie);
            }
        }
        public IActionResult ModifyOverview()
        {
            var movies = MoviesService.GetAll();
            var modifyOverviewModels = movies
                .Select(x => ModelConvertor.ConverToModifyOverviewModel(x))
                .ToList();
            return View(modifyOverviewModels);
        }
        public IActionResult Modify(int id)
        {
            var movie = MoviesService.GetById(id);
            var movieModify = ModelConvertor.ConvertToMovieModifyModel(movie);
            return View(movieModify);
        }
        [HttpPost]
        public IActionResult Modify(MovieModifyModel movieModifyModel)
        {
            if (ModelState.IsValid)
            {
                var movie = ModelConvertor.ConvertFromMoviesModifyModel(movieModifyModel);
                MoviesService.UpdateMovie(movie);
                return RedirectToAction("ModifyOverview");
            }
            return View(movieModifyModel);
        }
        public IActionResult Delete(int id)
        {
            MoviesService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }
    }
}