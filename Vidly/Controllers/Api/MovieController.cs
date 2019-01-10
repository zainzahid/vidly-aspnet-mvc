using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class MovieController : ApiController
    {
        ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        
        //GET /api/movie
        public IHttpActionResult GetMovie(string query=null)
        {
            var movieDto = _context.Movie
                .Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            if( !String.IsNullOrWhiteSpace(query) )
                movieDto = _context.Movie
                .Where(c => c.Name.Contains(query))
                .Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok( movieDto );
        }

        //GET /api/movie
        public IHttpActionResult GetMovie( int id )
        {
            var movieInDb = _context.Movie
                .Include(b => b.Genre)
                .SingleOrDefault(b => b.Id == id);
            if (movieInDb == null)
                return NotFound();
            return Ok(Mapper.Map<Movie,MovieDto>(movieInDb));
        }
        
        //POST /api/movie/id
        [HttpPost]
        public IHttpActionResult CreateMovie( MovieDto movieDto )
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movie.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri+"/"+movieDto.Id),movieDto);
        }

        //PUT /api/movie/id
        [HttpPut]
        public void UpdateMovie( int id, MovieDto movieDto )
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movie
                .Include(b => b.Genre)
                .SingleOrDefault(b => b.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
        }

        //DELETE /api/movie/id
        [HttpDelete]
        public void DeleteMovie( int id )
        {
            var movieInDb = _context.Movie
                            .Include(b => b.Genre)
                            .SingleOrDefault(b => b.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();
        }

    }
}
