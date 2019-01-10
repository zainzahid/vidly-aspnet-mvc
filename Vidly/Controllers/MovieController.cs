using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movie.Include(b => b.Genre).ToList();
            if (User.Identity.IsAuthenticated)
            {
                return View("Movies", movies);
            }
            return View("MoviesReadOnly", movies);
        }

        // GET: Movie

        [Route("Movie/{Edit}/{id}")]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movie
                        .SingleOrDefault(b => b.Id == id);
            var movieFormViewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",movieFormViewModel);
        }

        [Authorize]
        public ActionResult Add()
        {
            var movieFormViewModel = new MovieFormViewModel() {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save( Movie movie )
        {
            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", movieFormViewModel);
            }

            if (movie.Id == 0)
            {
                movie.NumbersAvailable = movie.NumbersInStock;
                _context.Movie.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movie
                                .Single(b => b.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumbersInStock = movie.NumbersInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        [Route("Movie/{Delete}/{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(b => b.Id == id);
            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();
            return RedirectToAction("Index","Movie");
        }
    }
}