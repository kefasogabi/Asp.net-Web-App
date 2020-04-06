using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProject.Models;
using WebProject.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace WebProject.Controllers.Api
{
    public class MovieController : ApiController
    {

        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /Api/Movies/
        [HttpGet]
        public IEnumerable<MovieDto> GetMovie( string query = null)
        {
            var moviequery = _context.Movies.Include(c => c.Genre)
                .Where(c => c.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviequery = moviequery.Where(c => c.Name.Contains(query));

            return moviequery
                .ToList()
                .Select(Mapper.Map<Movies, MovieDto>);

            
        }

        //Get/Api/Movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return NotFound();

            return Ok(Mapper.Map<Movies, MovieDto>(movies));

        }

        //Post/Api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movies>(movieDto);

            movie.DateAdded = DateTime.Now;
            movie.NumberAvailable = movie.NumberInStock;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);


        }

        //Put/Api/Movie/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieInDb, movieDto);

            _context.SaveChanges();



           

        }

        public void Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            
        }
    }
}
