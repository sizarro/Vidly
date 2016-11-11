using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext context;

        public MoviesController()
        {
            context = new ApplicationDbContext();
        }

        // GET: api/Movies
        public IHttpActionResult GetMovies()
        {
            var movies = context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }

        // GET: api/Movies/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST: api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            context.Movies.Add(movie);
            context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT: api/Movies/5
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDto, movieInDb);

            context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Movies/5
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            context.Movies.Remove(movieInDb);
            context.SaveChanges();

            return Ok();
        }
    }
}
