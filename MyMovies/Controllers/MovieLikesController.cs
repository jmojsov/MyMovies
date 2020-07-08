using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class MovieLikesController : Controller
    {
        public IActionResult Like([FromBody] MovieLikeViewModel movieLikeViewModel)
        {
            return Ok();
        }
    }
}