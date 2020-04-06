using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProject.Dtos;
using System.Data.Entity;
using WebProject.Models;

namespace WebProject.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult NewRentals( NewRentalDto newRental)
        {
            var customer = _context.Customers.
                Single(c => c.Id == newRental.CustomerId);


            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            foreach ( var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customers = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                };

                _context.Rental.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
