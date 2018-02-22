using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.viewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose(); 
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();            //GetMovies();    
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel 
            {
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                 Console.WriteLine(e);
            }
            
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
        }


        //public ActionResult Random()
        //{
        //    ////initialize the movie object
        //    //var movie = new Movie() { Name = "Shrek!" };

        //    ////initialize the customer object
        //    //var customers = new List<Customer>
        //    //{
        //    //    new Customer { Name = "Customer 1"},
        //    //    new Customer {Name = "Customer 2" }
        //    //};

        //    ////Initialize the viewModel with this two objects above which are its properties
        //    //var viewModel = new RandomMovieViewModel
        //    //{
        //    //    Movie = movie,
        //    //    Customers= customers
        //    //};

        //    //return View(viewModel);

        //    //return View(movie);
        //    //return Content("Heloo World");
        //    //return HttpNotFound();
        //    // return new EmptyResult();
        //    //return RedirectToAction("Index", "Home", new { page = 1, SortBy = "name" });
        //}

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
           {
                new Movie { Id = 1, Name = "Shrek" },
               new Movie { Id = 2, Name = "Wall-e" }
           };
        }


        //public ActionResult Edit(int id)
        //{
        //    return Content("You entered Id= " + id);
        //}


        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("pageIndex= {0} and sortBy= {1}", pageIndex, sortBy));
        //}


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " / " + month);
        }


    }
}