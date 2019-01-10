using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class RentController : ApiController
    {
        ApplicationDbContext _context;

        public RentController()
        {
            _context = new ApplicationDbContext();
        }

        //POST /api/rent
        [HttpPost]
        public IHttpActionResult CreateRent(AddRentalDto addRentalDto)
        {
            var customerInDb = _context.Customer.Single(
                c => c.Id == addRentalDto.CustomerId);

            var moviesInDb = _context.Movie.Where(
                m => addRentalDto.MovieIds.Contains(m.Id));//below is alternative way

            //var moviesInDb = new List<Movie>();
            //foreach (var movieId in addRentalDto.MovieIds)
            //{
            //    moviesInDb.Add(_context.Movie.Single(m => m.Id == movieId));
            //}

            foreach (var movie in moviesInDb)
            {
                if (movie.NumbersAvailable == 0)
                    return BadRequest("Movie is not Available");
                movie.NumbersAvailable--;
                var rental = new Rental()
                {
                    Movie = movie,
                    Customer = customerInDb,
                    DateRented = DateTime.Now
                };
                _context.Rental.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
     }
}
