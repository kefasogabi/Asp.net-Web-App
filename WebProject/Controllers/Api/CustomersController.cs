using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProject.Dtos;
using WebProject.Models;
using System.Data.Entity;

namespace WebProject.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Get /Api/ Customer
        [HttpGet]
        public IHttpActionResult GetCustomer( string query = null)
        {
            var customersquery = _context.Customers.Include(c => c.MembershipType);


                if (!string.IsNullOrWhiteSpace(query))
                customersquery = customersquery.Where(c => c.Name.Contains(query));
                
                var customerDto = customersquery
                .ToList()
                .Select(Mapper.Map<Customers, CustomerDto >);

            return Ok(customerDto);

        }

        // Get /Api/Customer/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok( Mapper.Map<Customers, CustomerDto>(customer));
        }


        // Post /Api/Customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customers>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }


        // Put / Api/Customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
           
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest); 

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerInDb, customerDto);

           

            _context.SaveChanges();
        }


        // Delete /Api/Customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

        }
    }
}
