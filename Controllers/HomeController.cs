using _413assignment3.Models;
using _413assignment3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _413assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult ViewMovies()
        {
            //return View(SubmittedMovies.FilteredMovies);
            return View(new MovieListViewModel
            {
                Movies = _repository.Movies
            }
            );
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie movie)
        {
            Debug.WriteLine(movie.Category);
            if (ModelState.IsValid)
            {
               _repository.AddMovie(movie);
            }
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModifyMovie(Movie movie)
        {
            Debug.Print("yo");
            int movieid = movie.MovieId;
            if (movieid == null)
            {
                return View("Index");
            }
            
            _repository.UpdateMovie(movie);

            return View("ViewMovies", new MovieListViewModel
            {
                Movies = _repository.Movies
            }
            );
        }

        [HttpGet]
        public IActionResult ModifyMovie(string movieid)
        {
            if (movieid == null)
            {
                return View("Error");
            }
            int theid = int.Parse(movieid);
            Movie m = _repository.Movies
                           .Where(m => m.MovieId == theid)
                           .FirstOrDefault<Movie>();

            return View(new ModifyMovieViewModel { Movie = m });
        }

        [HttpPost]
        public IActionResult DeleteMovie(string movieid)
        {
            if (movieid == null)
            {
                return View("Error");
            }

            int theid = int.Parse(movieid);
            Movie movie = _repository.Movies
                           .Where(m => m.MovieId == theid)
                           .FirstOrDefault<Movie>();

            _repository.DeleteMovie(movie);

            return View("ViewMovies", new MovieListViewModel
            {
                Movies = _repository.Movies
            }
            );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
