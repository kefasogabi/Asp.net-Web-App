using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.ViewModel;
using System.Data.Entity;

namespace WebProject.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            

            //if (User.IsInRole(RoleName.CanManageMovies))

            return View("List");

           // return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }


        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()   
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
               
                Genre = genre
            };

            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Movies movies)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movies)
                {
                    Genre = _context.Genres.ToList(),
                   
                };
                

                return View("MoviesForm", viewModel);
            }

            if (movies.Id == 0)
            {
                movies.NumberAvailable = movies.NumberInStock;
                movies.DateAdded = DateTime.Now;
                _context.Movies.Add(movies);

            }
            else
            {

                var movieInDb = _context.Movies.Single(m => m.Id == movies.Id);

                movieInDb.Name = movies.Name;
                movieInDb.NumberInStock = movies.NumberInStock;
                movieInDb.GenreId = movies.GenreId;
                movieInDb.ReleaseDate = movies.ReleaseDate;
                movieInDb.DateAdded = movies.DateAdded;

            }
           

            _context.SaveChanges();

           return RedirectToAction("index", "Movies");
            
        }

        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();


            var viewModel = new MovieFormViewModel (movies)
            {
                
                Genre = _context.Genres.ToList()

            };
            return View("MoviesForm", viewModel);
        }

    }
}