using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;


namespace Vidly.Controllers.Api
{
    public class CustomerController : ApiController
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose( bool disposing )
        {
            _context.Dispose();
        }

        //GET api/customer/ 
        public IHttpActionResult GetCustomer(string query = null)
        {
            var customerDto = _context.Customer
                .Select(Mapper.Map<Customer, CustomerDto>).ToList();

            if (!String.IsNullOrWhiteSpace(query))
                customerDto = _context.Customer
                    .Where( c=> c.Name.Contains(query) )
                    .Select(Mapper.Map<Customer, CustomerDto>).ToList();

            return Ok(customerDto);
        }

        //GET api/customer/id
        public IHttpActionResult GetCustomer( int id )
        {
            var customer = _context.Customer
                           .SingleOrDefault(b=>b.Id==id);
            if (customer == null)
                return NotFound();
            return Ok( Mapper.Map<Customer, CustomerDto>(customer) );
        }

        //POST api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer( CustomerDto customerDto )
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customer.Add(customer);
            _context.SaveChanges();
            //Now we need Id of Customer which is auto genereted when
            //adding to the DB
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        //PUT api/customer/id
        [HttpPut]
        public void UpdateCustomer( int id, CustomerDto customerDto )
        {
            if ( !ModelState.IsValid )
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customer
                              .SingleOrDefault(b => b.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
        }

        //DELETE api/customer/id
        [HttpDelete]
        public void DeleteCustomer( int id )
        {
            var customerInDb = _context.Customer
                              .SingleOrDefault(b => b.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customer.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
